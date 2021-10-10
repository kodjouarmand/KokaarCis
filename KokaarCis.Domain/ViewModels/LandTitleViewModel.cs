using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class LandTitleViewModel
    {
        public LandTitleDto LandTitle { get; set; }
        public IEnumerable<LandTitleDocumentDto> LandTitleDocuments { get; set; }
        public IEnumerable<SelectListItem> LocalityList { get; set; }
        public bool ReturnToDetailView { get; set; }
    }
}
