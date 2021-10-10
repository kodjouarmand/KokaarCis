using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerDto Customer { get; set; }
        public IEnumerable<CustomerDocumentDto> CustomerDocuments { get; set; }
        public IEnumerable<SelectListItem> IdentityDocumentTypeList { get; set; }
        public bool ReturnToDetailView { get; set; }
        public int? InvoiceHeaderId { get; set; }
    }
}
