using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class InvoiceHeaderViewModel
    {
        public InvoiceHeaderDto InvoiceHeader { get; set; }
        public IEnumerable<InvoiceDetailDto> InvoiceDetails { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> BusinessPartnerList { get; set; }
        public IEnumerable<SelectListItem> CommissionTypeList { get; set; }
        public InvoiceDetailDto InvoiceDetail { get; set; }
        public IEnumerable<SelectListItem> ParcelList { get; set; }
        public bool ReturnToHeaderView { get; set; }
        public bool ReturnToViewCommission { get; set; }
        
    }
}
