using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IInvoiceHeaderRepository : IBaseRepository<InvoiceHeader, int>
    {
        public void Update(InvoiceHeader invoiceHeader);
    }
}
