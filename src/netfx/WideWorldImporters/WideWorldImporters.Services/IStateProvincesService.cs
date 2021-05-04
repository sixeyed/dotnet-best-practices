using System.ServiceModel;
using WideWorldImporters.Services.Contracts;

namespace WideWorldImporters.Services
{
    [ServiceContract]
    public interface IStateProvincesService
    {
        [OperationContract]
        GetStateProvincesResponse GetStateProvinces(GetStateProvincesRequest request);
    }
}
