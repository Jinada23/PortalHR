using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalHR.Service.Services
{
    public class UserGrpcService : UserService.UserServiceBase
    {
        private readonly ILogger<UserGrpcService> _logger;
        public UserGrpcService(ILogger<UserGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RegisterReply
            {
                Message = "Hello " + request.User.Firstname
            });
        }

        public override Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LoginResponse
            {
                Message = "Hello " + request.Username
            });
        }

        public override Task<GetUserResponse> GetUserById(GetUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetUserResponse
            {
                User = new User
                {
                    Firstname = "George",
                    Lastname = "Dumbrava",
                    Email = "george.dumbrava@endava.com"
                }
            });
        }

        public override Task<GetAllUsersResponse> GetAllUsers(GetAllUsersRequest request, ServerCallContext context)
        {
            var users = new GetAllUsersResponse();

            users.Users.AddRange(new List<User> {
                new User { Firstname = "George", Lastname = "Dumbrava"},
                new User { Firstname = "Vadim", Lastname = "Papuc", Address = "Str. Lev Tolsoi 74"}
            });

            return Task.FromResult(users);
            
        }
    }
}
