using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IIdentityDocumentTypeRepository : IBaseRepository<IdentityDocumentType, int>
    {
        public void Update(IdentityDocumentType city);        
    }
}
