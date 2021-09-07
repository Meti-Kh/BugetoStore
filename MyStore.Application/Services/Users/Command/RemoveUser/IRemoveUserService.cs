using MyStore.Common.Dto;

namespace Bugeto_Store.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserID);
    }
}
