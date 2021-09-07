using System.Collections.Generic;
using System.Linq;
using MyStore.Application.Interfaces.Context;
using MyStore.Common;

namespace MyStore.Application.Services.Users.Query.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        IDatabaseContext _context;

        public GetUsersService(IDatabaseContext _databaseContext)
        {
            _context = _databaseContext;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var Users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.searchKey))
            {
                Users = Users.Where(u => u.FullName.Contains(request.searchKey) || u.Email.Contains(request.searchKey));
            }

            int rowsCount = 0;
            var UserList= Users.ToPaged(request.Page, 20, out rowsCount).Select(u => new GetUsersDto
                {
                    ID = u.ID,
                    FullName = u.FullName
                    ,
                    Email = u.Email,
                    IsActive = u.IsActive
                }).
                ToList();

            return new ResultGetUserDto{Users = UserList,Rows = rowsCount};
        }
    }
}