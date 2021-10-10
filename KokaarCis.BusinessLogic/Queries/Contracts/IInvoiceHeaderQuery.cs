using KokaarCis.BusinessLogic.Queries;
using KokaarCis.Domain.Assemblers;
using System;
using System.Collections.Generic;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface IInvoiceHeaderQuery : IBaseQuery<InvoiceHeaderDto, int>
    {
        InvoiceHeaderDto GetByNumber(string number);
        IEnumerable<InvoiceHeaderDto> GetCommissions();
        IEnumerable<InvoiceHeaderDto> GetUnpaidCommissions();
    }
}