using System.Threading.Tasks;
using Designer.Common.Model.Request;
using Designer.Common.Model.Response;

namespace Designer.Service.API.Service.Protocol
{
    public interface IMeshService
    {
        Task<GenerateAllAvailablePositionsResponseModel> Generate(GenerateAllAvailablePositionsBindingModel model);
    }
}

