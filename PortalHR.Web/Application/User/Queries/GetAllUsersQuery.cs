using MediatR;
using PortalHR.Web.Grpc.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PortalHR.Web.Application.User.Queries
{
    public class GetAllUsersQuery : IRequest<List<Web.User>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<Web.User>>
    {
        public UserGrpcService service { get; set; }
        public GetAllUsersQueryHandler()
        {
            service = new UserGrpcService();
        }
        public async Task<List<Web.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetAllUsers(new GetAllUsersRequest());
            
            var users = new List<Web.User>();

            users.AddRange(result.Users);

            return users;
        }
    }
}
