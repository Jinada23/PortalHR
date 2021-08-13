using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalHR.Web.Application.User.Commands;
using System.Threading.Tasks;

namespace PortalHR.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IMediator _mediator;

        public RegisterController(ILogger<RegisterController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<string> Register()
        {
            var request = new UserRegisterCommand();

            var response = await _mediator.Send(request);

            return response.Message;
        }
    }
}
