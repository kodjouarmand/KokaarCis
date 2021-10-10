using KokaarCis.Domain.Entities;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class ParcelDocumentRepository : BaseRepository<ParcelDocument, int>, IParcelDocumentRepository
    {
        public ParcelDocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public virtual void Update(ParcelDocument parcelDocumentToUpdate)
        {
            var originalEntity = GetById(parcelDocumentToUpdate.Id);

            originalEntity.DocumentTypeId = parcelDocumentToUpdate.DocumentTypeId;
            originalEntity.ParcelId = parcelDocumentToUpdate.ParcelId;
            if (!string.IsNullOrWhiteSpace(parcelDocumentToUpdate.DocumentUrl)) originalEntity.DocumentUrl = parcelDocumentToUpdate.DocumentUrl;
            originalEntity.LastModificationDate = parcelDocumentToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = parcelDocumentToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
