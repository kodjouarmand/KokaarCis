using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KokaarCis.Mvc
{
    [Area("User")]
    public class BaseUserController : BaseController
    {
        public BaseUserController(ILoggerService logger, IApplicationUserQuery applicationUserQuery)
            : base(logger, applicationUserQuery) { }
    }
}
