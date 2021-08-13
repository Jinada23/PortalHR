using Grpc.Net.Client;
using System.Threading.Tasks;
using static PortalHR.Web.UserService;

namespace PortalHR.Web.Grpc.Services
{
    public class UserGrpcService
    {
        public readonly UserServiceClient _client;
        public UserGrpcService()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new UserServiceClient(channel);
        }

        public async Task<RegisterReply> Register(RegisterRequest request)
        {
            return await _client.RegisterAsync(request);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _client.LoginAsync(request);
        }
        public async Task<GetUserResponse> GetUserById(GetUserRequest request)
        {
            return await _client.GetUserByIdAsync(request);
        }
        public async Task<GetAllUsersResponse> GetAllUsers(GetAllUsersRequest request)
        {
            return await _client.GetAllUsersAsync(request);
        }
    }
}
