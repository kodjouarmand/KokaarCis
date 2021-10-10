using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ILandTitleDocumentRepository : IBaseRepository<LandTitleDocument, int>
    {
        public void Update(LandTitleDocument landTitleDocument);        
    }
}
