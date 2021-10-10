using KokaarCis.Domain.Entities;
using System;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class LandTitleRepository : BaseRepository<LandTitle, int>, ILandTitleRepository
    {
        public LandTitleRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(LandTitle landTitleToUpdate)
        {
            var originalEntity = GetById(landTitleToUpdate.Id);

            if (!string.IsNullOrWhiteSpace(landTitleToUpdate.Number)) originalEntity.Number = landTitleToUpdate.Number;
            if (!string.IsNullOrWhiteSpace(landTitleToUpdate.Owner)) originalEntity.Owner = landTitleToUpdate.Owner;
            originalEntity.LocalityId = landTitleToUpdate.LocalityId;
            originalEntity.Surface = landTitleToUpdate.Surface;          
            if (!string.IsNullOrWhiteSpace(landTitleToUpdate.Description)) originalEntity.Description = landTitleToUpdate.Description;
            originalEntity.LastModificationDate = landTitleToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = landTitleToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
