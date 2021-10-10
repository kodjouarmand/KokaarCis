using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ICustomerDocumentRepository : IBaseRepository<CustomerDocument, int>
    {
        public void Update(CustomerDocument customerDocument);        
    }
}
