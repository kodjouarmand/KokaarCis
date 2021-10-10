using KokaarCis.Domain.Assemblers;
using System.Collections.Generic;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface ICommissionPaymentQuery : IBaseQuery<CommissionPaymentDto, int>
    {
        IEnumerable<CommissionPaymentDto> GetByInvoiceHeaderId(int invoiceHeaderId);
    }
}