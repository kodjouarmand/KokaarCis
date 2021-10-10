using KokaarCis.Domain.Entities;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class LandTitleDocumentRepository : BaseRepository<LandTitleDocument, int>, ILandTitleDocumentRepository
    {
        public LandTitleDocumentRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(LandTitleDocument landTitleDocumentToUpdate)
        {
            var originalEntity = GetById(landTitleDocumentToUpdate.Id);

            originalEntity.DocumentTypeId = landTitleDocumentToUpdate.DocumentTypeId;
            originalEntity.LandTitleId = landTitleDocumentToUpdate.LandTitleId;
            if (!string.IsNullOrWhiteSpace(landTitleDocumentToUpdate.DocumentUrl)) originalEntity.DocumentUrl = landTitleDocumentToUpdate.DocumentUrl;
            originalEntity.LastModificationDate = landTitleDocumentToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = landTitleDocumentToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
