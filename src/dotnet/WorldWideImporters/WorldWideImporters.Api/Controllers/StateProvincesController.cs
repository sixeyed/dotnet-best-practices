using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WorldWideImporters.Data;
using model = WorldWideImporters.Model;

namespace WorldWideImporters.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateProvincesController : ControllerBase
    {
        private static List<model.StateProvince> _StateProvinces = null;

        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly WorldWideImportersContext _context;

        public StateProvincesController(IConfiguration config)
        {
            _config = config;
            _logger = LoggerFactory.Create(cfg => cfg.AddConsole()).CreateLogger<StateProvince>();

            var builder = new DbContextOptionsBuilder<WorldWideImportersContext>()
                                        .UseSqlServer(_config.GetConnectionString("wwi-db"));
            _context = new WorldWideImportersContext(builder.Options);
        }

        [HttpGet]
        public IEnumerable<model.StateProvince> Get()
        {
            _logger.LogDebug("GetStateProvinces started");

            var provinces = new List<model.StateProvince>();

            var useCache = _config.GetValue<bool>("UseCache");
            if (useCache == false || _StateProvinces == null)
            {
                var stopwatch = Stopwatch.StartNew();
                foreach (var province in _context.StateProvinces.Include(x=>x.Country))
                {
                    provinces.Add(new model.StateProvince
                    {
                        CountryIsoCode = province.Country.IsoAlpha3Code,
                        StateProvinceCode = province.StateProvinceCode,
                        StateProvinceName = province.StateProvinceName
                    });
                }
                _logger.LogDebug("GetStateProvinces data load took: " + stopwatch.ElapsedMilliseconds + "ms");
                if (useCache)
                {
                    _StateProvinces = provinces;
                }
            }

            IEnumerable<model.StateProvince> response = useCache ? _StateProvinces : provinces;
            _logger.LogDebug("GetStateProvinces returning: " + response.Count() + " provinces; using cache: " + useCache);

            return response;
        }
    }
}