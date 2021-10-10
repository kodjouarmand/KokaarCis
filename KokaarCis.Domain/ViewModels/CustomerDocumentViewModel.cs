using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class CustomerDocumentViewModel
    {
        public CustomerDocumentDto CustomerDocument { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> DocumentTypeList { get; set; }
        public bool ReturnToIndexView { get; set; }
    }
}
