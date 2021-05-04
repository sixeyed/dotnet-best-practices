using System.Collections.Generic;
using WideWorldImporters.Services.Entities;

namespace WideWorldImporters.Services.Contracts
{
    public class GetCitiesResponse
    {
        public string StateProvinceCode { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}