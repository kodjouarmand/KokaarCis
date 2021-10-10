using KokaarCis.Domain.Assemblers;
using System;
using System.Text;

namespace KokaarCis.BusinessLogic.Commands.Contracts
{
    public interface IInvoicePaymentCommand : IBaseCommand<InvoicePaymentDto, int>
    {

    }
}