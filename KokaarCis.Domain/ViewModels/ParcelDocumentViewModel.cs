using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class ParcelDocumentViewModel
    {
        public ParcelDocumentDto ParcelDocument { get; set; }
        public IEnumerable<SelectListItem> ParcelList { get; set; }
        public IEnumerable<SelectListItem> DocumentTypeList { get; set; }
        public bool ReturnToIndexView { get; set; }
    }
}
