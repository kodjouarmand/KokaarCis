using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IDocumentTypeRepository : IBaseRepository<DocumentType, int>
    {
        public void Update(DocumentType documentType);        
    }
}
