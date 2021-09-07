using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyStore.Common.Dto;

namespace MyStore.Application.Services.Users.Command.CraeteUser
{
   public interface ICreateUserService
   {
       ResultDto<ResultCreateUserDto> Execute(RequestCreateUserDto request);
   }
}
