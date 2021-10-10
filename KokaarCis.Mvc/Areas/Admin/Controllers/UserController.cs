using System;
using System.Linq;
using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.Domain.Contexts;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Utility.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace KokaarCis.Mvc.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ILoggerService logger, IApplicationUserQuery applicationUserQuery,
            ApplicationDbContext dbContext)
            : base(logger, applicationUserQuery)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentUser = CurrentUser;
            return View();
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            System.Collections.Generic.List<Domain.Entities.ApplicationUser> userList = _dbContext.ApplicationUsers.ToList();
            System.Collections.Generic.List<Microsoft.AspNetCore.Identity.IdentityUserRole<Guid>> userRole = _dbContext.UserRoles.ToList();
            System.Collections.Generic.List<Domain.Entities.ApplicationRole> roles = _dbContext.Roles.ToList();
            foreach (Domain.Entities.ApplicationUser user in userList)
            {
                Guid roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.RoleName = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            if (!_applicationUserQuery.IsSuperAdministrator(CurrentUser))
                userList.RemoveAll(u => u.RoleName.Equals(ConstantHelper.ROLE_NAME_SUPER_ADMIN));

            return Json(new { data = userList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] Guid id)
        {
            Domain.Entities.ApplicationUser objFromDb = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked, we will unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _dbContext.SaveChanges();
            return Json(new { success = true, message = "Operation Successful." });
        }

        #endregion
    }
}