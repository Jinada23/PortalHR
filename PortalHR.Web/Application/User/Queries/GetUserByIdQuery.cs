using MediatR;
using PortalHR.Web.Grpc.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PortalHR.Web.Application.User.Queries
{
    public class GetUserByIdQuery : IRequest<Web.User>
    {
        public string UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Web.User>
    {
        public UserGrpcService service { get; set; }
        public GetUserByIdQueryHandler()
        {
            service = new UserGrpcService();
        }
        public async Task<Web.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var getUserRequest = new GetUserRequest
            {
                UserId = request.UserId,
                Token = "123123"
            };

            var response = await service.GetUserById(getUserRequest);

            return response.User;
        }
    }
}
