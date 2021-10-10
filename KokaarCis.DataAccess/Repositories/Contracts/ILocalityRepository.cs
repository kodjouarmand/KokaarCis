using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ILocalityRepository : IBaseRepository<Locality, int>
    {
        public void Update(Locality locality);        
    }
}
