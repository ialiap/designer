using System.Net;
using System.Threading.Tasks;
using Designer.Common.Model.Request;
using Designer.Common.Model.Response;
using Designer.Service.API.Service.Protocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Annotations;

namespace Designer.Service.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : ControllerBase
    {
        private readonly IMeshService _meshService;
        private readonly ILogger<GenerateController> _logger;

        public GenerateController(ILogger<GenerateController> logger, IMeshService meshService)
        {
            _logger = logger;
            _meshService = meshService;

        }

        /// <summary>
        /// Generate Positions
        /// </summary>
        /// <param name="requestModel">Generate All Available Positions Binding Model </param>
        /// <returns>Coordinates</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GenerateAllAvailablePositionsResponseModel))]
        public async Task<IActionResult> Post(GenerateAllAvailablePositionsBindingModel requestModel)
        {
            return Ok(await _meshService.Generate(requestModel));
        }


    }
}
