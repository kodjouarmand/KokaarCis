using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ICityRepository : IBaseRepository<City, int>
    {
        public void Update(City city);        
    }
}
