using System.Collections.Generic;
using MyStore.Application.Interfaces.Context;
using MyStore.Common;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Users;

namespace MyStore.Application.Services.Users.Command.CraeteUser
{
    public class CreateUserService : ICreateUserService
    {
        private IDatabaseContext _context;

        public CreateUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultCreateUserDto> Execute(RequestCreateUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultCreateUserDto>()
                    {
                        IsSuccess = false,
                        Data = new ResultCreateUserDto() { UserID = 0 },
                        Message = "لطفا نام کامل خود را وارد کنید",
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultCreateUserDto>()
                    {
                        IsSuccess = false,
                        Data = new ResultCreateUserDto() { UserID = 0 },
                        Message = "لطفا ایمیل خود را وارد کنید",
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultCreateUserDto>()
                    {
                        IsSuccess = false,
                        Data = new ResultCreateUserDto() { UserID = 0 },
                        Message = "لطفا رمز خود را وارد کنید",
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultCreateUserDto>()
                    {
                        IsSuccess = false,
                        Data = new ResultCreateUserDto() { UserID = 0 },
                        Message = "رمز ها همخوانی ندارند",
                    };
                }

                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword( request.Password);

                User user = new User() { FullName = request.FullName, Email = request.Email, IsActive = true,Password = hashedPassword};


                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var roles = _context.Roles.Find(item.ID);
                    userInRoles.Add(new UserInRole { Role = roles, RoleID = roles.ID, User = user, UserID = user.ID });
                }

                user.UserInRoles = userInRoles;
                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResultDto<ResultCreateUserDto>()
                {
                    Data = new ResultCreateUserDto() { UserID = user.ID, },
                    IsSuccess = true,
                    Message = "ثبت انجام شد",
                };
            }
            catch
            {

                return new ResultDto<ResultCreateUserDto>()
                {
                    IsSuccess = false,
                    Data = new ResultCreateUserDto() { UserID = 0 },
                    Message = "ثبت نام انجام نشد",
                };

            }
        }
    }
}