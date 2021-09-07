using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStore.Domain.Entities.Users;

namespace MyStore.Application.Services.Users.Query.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}