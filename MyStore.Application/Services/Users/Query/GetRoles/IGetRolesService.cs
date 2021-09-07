using System.Collections.Generic;
using MyStore.Common.Dto;

namespace Bugeto_Store.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
