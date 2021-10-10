using KokaarCis.Domain.Entities;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class DocumentTypeRepository : BaseRepository<DocumentType, int>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(DocumentType documentTypeToUpdate)
        {
            var originalEntity = GetById(documentTypeToUpdate.Id);

            if (!string.IsNullOrWhiteSpace(documentTypeToUpdate.Name)) originalEntity.Name = documentTypeToUpdate.Name;
            originalEntity.LastModificationDate = documentTypeToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = documentTypeToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
