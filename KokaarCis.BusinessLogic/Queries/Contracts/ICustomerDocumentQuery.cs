using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface ICustomerDocumentQuery : IBaseQuery<CustomerDocumentDto, int>
    {
        CustomerDocumentDto GetByDocumentUrl(string documentUrld);
        IEnumerable<CustomerDocumentDto> GetByCustomerId(int customerId);
    }
}