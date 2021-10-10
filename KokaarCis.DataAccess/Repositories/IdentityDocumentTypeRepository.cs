using KokaarCis.Domain.Entities;
using System;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class IdentityDocumentTypeRepository : BaseRepository<IdentityDocumentType, int>, IIdentityDocumentTypeRepository
    {
        public IdentityDocumentTypeRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(IdentityDocumentType cityToUpdate)
        {
            var originalEntity = GetById(cityToUpdate.Id);

            if (!string.IsNullOrWhiteSpace(cityToUpdate.Name)) originalEntity.Name = cityToUpdate.Name;
            originalEntity.LastModificationDate = cityToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = cityToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
