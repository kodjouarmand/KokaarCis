using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ILandTitleRepository : IBaseRepository<LandTitle, int>
    {
        public void Update(LandTitle landTitle);        
    }
}
