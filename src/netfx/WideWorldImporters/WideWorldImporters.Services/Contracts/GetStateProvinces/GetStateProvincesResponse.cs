using System.Collections.Generic;
using WideWorldImporters.Services.Entities;

namespace WideWorldImporters.Services.Contracts
{
    public class GetStateProvincesResponse
    {
        public IEnumerable<StateProvince> StateProvinces { get; set; }
    }
}