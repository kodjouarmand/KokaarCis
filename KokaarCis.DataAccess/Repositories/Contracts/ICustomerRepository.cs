using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        public void Update(Customer customer);        
    }
}
