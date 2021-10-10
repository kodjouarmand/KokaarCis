using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IParcelDocumentRepository : IBaseRepository<ParcelDocument, int>
    {
        public void Update(ParcelDocument parcelDocument);        
    }
}
