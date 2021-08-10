using Google.Protobuf.WellKnownTypes;
using MediatR;
using PortalHR.Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortalHR.Web.Application.User.Commands
{
    class UserRegisterCommand : IRequest<string>
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

    class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, string>
    {
        public UserRegisterService service { get; set; }
        public UserRegisterCommandHandler()
        {
            service = new UserRegisterService();
        }
        public async Task<string> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = new RegisterRequest
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
            };

            var result = await service.Register(registerRequest);  
            
            return result;
        }
    }
}
