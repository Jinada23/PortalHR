using Google.Protobuf.WellKnownTypes;
using MediatR;
using PortalHR.Web.Grpc.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PortalHR.Web.Application.User.Commands
{
    public class UserLoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; } = "default";
        public string Password { get; set; } = "default";
        public DateTime LastLogin { get; set; } = DateTime.Now;
        public string IpAddress { get; set; } = "default";
    }

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, LoginResponse>
    {
        public UserGrpcService service { get; set; }
        public UserLoginCommandHandler()
        {
            service = new UserGrpcService();
        }
        public async Task<LoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var loginRequest = new LoginRequest
            {
                Username = request.Username,
                Password = request.Password,
                Ipaddress = request.IpAddress,
                LastLogin = Timestamp.FromDateTime(DateTime.SpecifyKind(request.LastLogin, DateTimeKind.Utc)),
            };

            return await service.Login(loginRequest);
        }
    }


}
