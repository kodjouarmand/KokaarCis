using System;
using System.Security.Claims;
using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.Domain.Entities;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Utility.Helpers;
using KokaarCis.Utility.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KokaarCis.Mvc.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly ILoggerService _logger;
        protected readonly IApplicationUserQuery _applicationUserQuery;
        public BaseController(ILoggerService logger, IApplicationUserQuery applicationUserQuery)
        {
            _logger = logger;
            _applicationUserQuery = applicationUserQuery;
        }

        public ApplicationUser CurrentUser
        {
            get => _applicationUserQuery.GetCurrentUser((ClaimsIdentity)User.Identity);
        }

        protected void CheckActionAuthorization()
        {
            if (!IdentityHelper.IsAdministrator(User))
            {
                throw new Exception("Vous n'êtes pas autorisé à effectuer cette opération.");
            }
        }
        
}
}
