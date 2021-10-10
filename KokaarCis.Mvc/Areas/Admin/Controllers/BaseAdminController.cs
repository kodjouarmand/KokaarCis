using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Mvc.Controllers;
using KokaarCis.Utility.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KokaarCis.Mvc
{
    [Area("Admin")]
    [Authorize(Roles = ConstantHelper.ROLE_NAME_SUPER_ADMIN + ", " + ConstantHelper.ROLE_NAME_ADMIN)]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(ILoggerService logger, IApplicationUserQuery applicationUserQuery)
            : base(logger, applicationUserQuery) { }
    }
}
