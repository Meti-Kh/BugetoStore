using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using Bugeto_Store.Application.Services.Users.Commands.RemoveUser;
using Bugeto_Store.Application.Services.Users.Commands.UserSatusChange;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Application.Services.Users.Command.CraeteUser;
using MyStore.Application.Services.Users.Query.GetUsers;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class UserController : Controller
    {
        private IGetUsersService _getUsersService;
        private IGetRolesService _getRolesService;
        private ICreateUserService _createUserService;
        private IRemoveUserService _removeUserService;
        private IEditUserService _editUserService;
        private IUserSatusChangeService _userSatusChangeService;
        public UserController(
            IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            ICreateUserService createUserService,
            IRemoveUserService removeUserService,
            IEditUserService editUserService,
            IUserSatusChangeService userSatusChangeService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _createUserService = createUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
            _userSatusChangeService = userSatusChangeService;
        }

        public IActionResult Index(string searchKey,int page)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto{Page = page,searchKey = searchKey}));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList( _getRolesService.Execute().Data,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string FullName, string Email, string Password, int RoleId, string RePassword)
        {
            var Result = _createUserService.Execute(new RequestCreateUserDto()
            {
                Email = Email,
                FullName = FullName,
                Password = Password,
                RePassword = RePassword,
                Roles = new List<RolesInCreateUserDto>()
                {
                    new RolesInCreateUserDto() {ID = RoleId}
                }

            });
            return Json(Result);
        }
        [HttpPost]
        public IActionResult Delete(long UserID)
        {
            return Json(_removeUserService.Execute(UserID));
        }
        [HttpPost]
        public IActionResult Edit(long UserID,string FullName,string Email)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                UserID = UserID,
                Email = Email,
                FullName = FullName
            }));
        }

        public IActionResult ChangeSatus(long UserID)
        {
            return Json(_userSatusChangeService.Execute(UserID));
        }
    }
}
