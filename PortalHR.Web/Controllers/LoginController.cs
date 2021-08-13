using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalHR.Web.Application.User.Commands;
using System.Threading.Tasks;

namespace PortalHR.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IMediator _mediator;

        public LoginController(ILogger<LoginController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<string> Login()
        {   
            var request = new UserLoginCommand();

            var response = await _mediator.Send(request);

            return response.Message;
        }
    }
}
