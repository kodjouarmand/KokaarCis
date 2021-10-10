using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KokaarCis.Domain.ViewModels
{
    public class LocalityViewModel
    {
        public LocalityDto Locality { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        public bool ReturnToDetailView { get; set; }
    }
}
