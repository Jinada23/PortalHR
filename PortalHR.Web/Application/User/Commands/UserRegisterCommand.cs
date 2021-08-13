using Google.Protobuf.WellKnownTypes;
using MediatR;
using PortalHR.Web.Grpc.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PortalHR.Web.Application.User.Commands
{
    class UserRegisterCommand : IRequest<RegisterReply>
    {
        public string FirstName { get; set; } = "default";
        public string LastName { get; set; } = "default";
        public string Email { get; set; } = "default";
        public DateTime DateOfBirth { get; set; } = new DateTime();
        public int MentorId { get; set; }
        public string PhoneNumber { get; set; } = "default";
        public string Address { get; set; } = "default";
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
    }

    class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, RegisterReply>
    {
        public UserGrpcService service { get; set; }
        public UserRegisterCommandHandler()
        {
            service = new UserGrpcService();
        }
        public async Task<RegisterReply> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {

            var registerRequest = new RegisterRequest
            {
                User = new Web.User
                {
                    Firstname = request.FirstName,
                    Lastname = request.LastName,
                    Email = request.Email,
                    Dateofbirth = Timestamp.FromDateTime(DateTime.SpecifyKind(request.DateOfBirth, DateTimeKind.Utc)),
                    MentorId = request.MentorId,
                    Phonenumber = request.PhoneNumber,
                    Address = request.Address,
                    DepartmentId = request.DepartmentId,
                    JobId = request.JobId
                    }

            };

            return await service.Register(registerRequest);
        }
    }
}
