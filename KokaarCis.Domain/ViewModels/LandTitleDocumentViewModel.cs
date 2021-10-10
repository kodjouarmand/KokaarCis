using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class LandTitleDocumentViewModel
    {
        public LandTitleDocumentDto LandTitleDocument { get; set; }
        public IEnumerable<SelectListItem> DocumentTypeList { get; set; }
    }
}
