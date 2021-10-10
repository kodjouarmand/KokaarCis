using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class InvoicePaymentViewModel
    {
        public InvoicePaymentDto InvoicePayment { get; set; }
        public IEnumerable<SelectListItem> InvoiceHeaderList { get; set; }
        public IEnumerable<SelectListItem> PaymentModeList { get; set; }
        public bool ReturnToDetailView { get; set; }        
    }
}
