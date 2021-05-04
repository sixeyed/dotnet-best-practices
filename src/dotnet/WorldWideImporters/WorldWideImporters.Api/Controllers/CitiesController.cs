using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WorldWideImporters.Data;
using model = WorldWideImporters.Model;

namespace WorldWideImporters.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly WorldWideImportersContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public CitiesController(WorldWideImportersContext context, IMapper mapper, IConfiguration config, ILogger<CitiesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
            _logger = logger;
        }

        [HttpGet("{stateProvinceCode}")]
        public async Task<IActionResult> Get(string stateProvinceCode)
        {
            // TODO - caching

            _logger.LogDebug($"GetCities for: {stateProvinceCode}, started");

            var cities = await _context.Cities
                                    .Include(x=>x.StateProvince)
                                    .Where(x => x.StateProvince.StateProvinceCode == stateProvinceCode)
                                    .ToArrayAsync();

            if (cities.Count() == 0)
            {
                _logger.LogDebug($"GetCities for:  {stateProvinceCode}, 0 found");
                return NotFound();
            }

            var modelCities = cities.Select(x => _mapper.Map<model.City>(x));

            _logger.LogDebug($"GetCities for: {stateProvinceCode}, returning: {modelCities.Count()} cities");
            return Ok(modelCities);
        }
    }
}
