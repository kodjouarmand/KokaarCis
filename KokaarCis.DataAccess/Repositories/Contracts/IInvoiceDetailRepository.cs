using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IInvoiceDetailRepository : IBaseRepository<InvoiceDetail, int>
    {
        public void Update(InvoiceDetail invoiceDetail);        
    }
}
