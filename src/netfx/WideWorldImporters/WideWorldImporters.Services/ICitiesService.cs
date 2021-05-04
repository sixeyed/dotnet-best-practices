using System.ServiceModel;
using WideWorldImporters.Services.Contracts;

namespace WideWorldImporters.Services
{
    [ServiceContract]
    public interface ICitiesService
    {
        [OperationContract]
        GetCitiesResponse GetCities(GetCitiesRequest request);
    }
}
