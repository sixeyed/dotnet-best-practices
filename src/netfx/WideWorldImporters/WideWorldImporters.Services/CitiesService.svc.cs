using AutoMapper;
using log4net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using WideWorldImporters.Data;
using WideWorldImporters.Services.Caching;
using WideWorldImporters.Services.Contracts;
using entities = WideWorldImporters.Services.Entities;

namespace WideWorldImporters.Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class CitiesService : ICitiesService
    {
        private readonly WideWorldImportersEntities _context;
        private readonly IMapper _mapper;
        private readonly ICache _cache;
        private readonly ILog _log;

        public CitiesService(WideWorldImportersEntities context, IMapper mapper, ICache cache, ILog log)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
            _log = log;
        }

        public GetCitiesResponse GetCities(GetCitiesRequest request)
        {
            _log.Debug($"GetCities for: {request.StateProvinceCode}, started");

            var response = new GetCitiesResponse
            {
                StateProvinceCode = request.StateProvinceCode
            };
            response.Cities = _cache.Get($"CitiesService.GetCities.{request.StateProvinceCode}", () =>
            {
                var stopwatch = Stopwatch.StartNew();
                var cities = new List<entities.City>();
                foreach (var city in _context.Cities.Where(x=>x.StateProvince.StateProvinceCode == request.StateProvinceCode))
                {
                    cities.Add(_mapper.Map<entities.City>(city));
                }
                _log.Debug($"GetCities data load for: {request.StateProvinceCode}, took: {stopwatch.ElapsedMilliseconds}ms");
                return cities;
            });

            _log.Info($"GetCities for: {request.StateProvinceCode}, returning: {response.Cities.Count()} cities, cache: {_cache.GetType().Name}");
            return response;
        }
    }
}
