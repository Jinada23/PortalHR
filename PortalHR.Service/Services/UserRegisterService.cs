using Grpc.Core;
using Microsoft.Extensions.Logging;
using PortalHR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalHR.Service.Services
{
    public class UserRegisterService : UserRegister.UserRegisterBase
    {
        private readonly ILogger<UserRegisterService> _logger;
        public UserRegisterService(ILogger<UserRegisterService> logger)
        {
            _logger = logger;
        }

        public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RegisterReply
            {
                Message = "Hello " + request.Firstname
            });
        }
    }
}
