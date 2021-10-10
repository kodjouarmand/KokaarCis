using System;
using System.Security.Claims;
using System.Security.Principal;
using KokaarCis.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface IApplicationUserQuery
    {
        ApplicationUser GetCurrentUser(ISession session);
        void SetCurrentUser(ISession session, ApplicationUser user);
        bool IsSuperAdministrator(ApplicationUser user);
        bool IsAdministrator(ApplicationUser user);
        ApplicationUser GetCurrentUser(ClaimsIdentity claimsIdentity);
        ApplicationUser GetUserById(Guid guid);
        string GetRoleName(ApplicationUser user);
        void Update(ApplicationUser user);
    }
}