using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IInvoicePaymentRepository : IBaseRepository<InvoicePayment, int>
    {
        public void Update(InvoicePayment invoicePayment);
    }
}
