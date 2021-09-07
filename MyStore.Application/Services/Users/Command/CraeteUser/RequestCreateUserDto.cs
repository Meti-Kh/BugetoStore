using System.Collections.Generic;

namespace MyStore.Application.Services.Users.Command.CraeteUser
{
    public class RequestCreateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInCreateUserDto> Roles { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool IsActive { get; set; }
    }
}