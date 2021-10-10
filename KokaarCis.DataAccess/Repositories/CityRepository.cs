using KokaarCis.Domain.Entities;
using System;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class CityRepository : BaseRepository<City, int>, ICityRepository
    {
        public CityRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(City cityToUpdate)
        {
            var originalEntity = GetById(cityToUpdate.Id);

            if (!string.IsNullOrWhiteSpace(cityToUpdate.Name)) originalEntity.Name = cityToUpdate.Name;
            originalEntity.LastModificationDate = cityToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = cityToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
