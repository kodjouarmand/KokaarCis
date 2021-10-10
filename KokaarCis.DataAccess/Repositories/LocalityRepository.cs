using KokaarCis.Domain.Entities;
using System;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class LocalityRepository : BaseRepository<Locality, int>, ILocalityRepository
    {
        public LocalityRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(Locality localityToUpdate)
        {
            var originalEntity = GetById(localityToUpdate.Id);

            originalEntity.CityId = localityToUpdate.CityId;
            if (!string.IsNullOrWhiteSpace(localityToUpdate.Name)) originalEntity.Name = localityToUpdate.Name;      
            if (!string.IsNullOrWhiteSpace(localityToUpdate.Description)) originalEntity.Description = localityToUpdate.Description;
            originalEntity.LastModificationDate = localityToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = localityToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
