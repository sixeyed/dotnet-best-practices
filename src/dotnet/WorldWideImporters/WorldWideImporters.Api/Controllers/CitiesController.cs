using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WorldWideImporters.Caching;
using WorldWideImporters.Data;
using model = WorldWideImporters.Model;

namespace WorldWideImporters.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly WorldWideImportersContext _context;
        private readonly ICache _cache;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CitiesController(WorldWideImportersContext context, IMapper mapper, ICache cache, ILogger<CitiesController> logger)
        {
            _context = context;
            _cache = cache;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{stateProvinceCode}")]
        public async Task<IActionResult> Get(string stateProvinceCode)
        {
            _logger.LogDebug($"GetCities for: {stateProvinceCode}, started");

            var cities = await _cache.GetAsync($"CitiesService.GetCities.{stateProvinceCode}", async () =>
            {
                return await _context.Cities
                              .Include(x => x.StateProvince)
                              .Where(x => x.StateProvince.StateProvinceCode == stateProvinceCode)
                              .ToArrayAsync();
            });

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
