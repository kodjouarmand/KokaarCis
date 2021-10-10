using KokaarCis.BusinessLogic.Queries;
using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Text;

namespace KokaarCis.BusinessLogic.Commands.Contracts
{
    public interface IInvoiceHeaderCommand : IBaseCommand<InvoiceHeaderDto, int>
    {
        void UpdateStatus(ref InvoiceHeader invoiceHeader);
        void UpdateAmounts(ref InvoiceHeader invoiceHeader);
        void UpdateCommissionStatus(ref InvoiceHeader invoiceHeader);
    }
}