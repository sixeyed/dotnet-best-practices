using log4net;
using log4net.Config;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using WideWorldImporters.Data;
using WideWorldImporters.Services.Contracts;
using entities = WideWorldImporters.Services.Entities;

namespace WideWorldImporters.Services
{
    public class StateProvincesService : IStateProvincesService
    {
        private static List<entities.StateProvince> _StateProvinces = null;

        public GetStateProvincesResponse GetStateProvinces(GetStateProvincesRequest request)
        {
            XmlConfigurator.Configure();
            var log = LogManager.GetLogger(typeof(StateProvincesService));
            log.Info("GetStateProvinces started");

            var provinces = new List<entities.StateProvince>();

            var useCache = bool.Parse(ConfigurationManager.AppSettings["UseCache"]);
            if (useCache == false || _StateProvinces == null)
            {
                var stopwatch = Stopwatch.StartNew();
                var context = new WideWorldImportersEntities();
                foreach (var province in context.StateProvinces)
                {
                    provinces.Add(new entities.StateProvince
                    {
                        CountryIsoCode = province.Country.IsoAlpha3Code,
                        StateProvinceCode = province.StateProvinceCode,
                        StateProvinceName = province.StateProvinceName
                    });
                }
                log.Info("GetStateProvinces data load took: " + stopwatch.ElapsedMilliseconds + "ms");
                if (useCache)
                {
                    _StateProvinces = provinces;
                }
            }

            var response = new GetStateProvincesResponse
            {
                StateProvinces = useCache ? _StateProvinces : provinces
            };
            log.Info("GetStateProvinces returning: " + response.StateProvinces.Count() + " provinces; using cache: " + useCache);
            return response;
        }
    }
}
