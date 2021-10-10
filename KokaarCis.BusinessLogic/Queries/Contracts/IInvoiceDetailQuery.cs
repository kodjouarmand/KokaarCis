using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface IInvoiceDetailQuery : IBaseQuery<InvoiceDetailDto, int>
    {
        IEnumerable<InvoiceDetailDto> GetByInvoiceHeaderId(int invoiceHeaderId);
        InvoiceDetailDto GetByParcelId(int parcelId);
    }
}