using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class InvoiceDetailViewModel
    {
        public InvoiceDetailDto InvoiceDetail { get; set; }
        public InvoiceHeaderDto InvoiceHeader { get; set; }
        public IEnumerable<SelectListItem> ParcelList { get; set; }
    }
}
