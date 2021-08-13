using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalHR.Web.Application.User.Commands;
using PortalHR.Web.Application.User.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalHR.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Web.User> Users(string id)
        {
            var request = new GetUserByIdQuery() { UserId = id };

            var response = await _mediator.Send(request);

            return response;
        }

        [HttpGet]
        public async Task<List<Web.User>> Users()
        {
            var request = new GetAllUsersQuery();

            var response = await _mediator.Send(request);

            return response;
        }
    }
}
