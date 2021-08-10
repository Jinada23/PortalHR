using Grpc.Net.Client;
using System.Threading.Tasks;
using static PortalHR.Web.UserRegister;

namespace PortalHR.Web.Infrastructure.Services
{
    public class UserRegisterService
    {
        public readonly UserRegisterClient _client;
        public  UserRegisterService()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new UserRegister.UserRegisterClient(channel);
        }

        public async Task<string> Register(RegisterRequest request)
        {
            var reply = await _client.RegisterAsync(request);

            return reply.Message;
        }
    }
}
