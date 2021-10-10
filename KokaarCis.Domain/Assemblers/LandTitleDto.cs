using System.ComponentModel.DataAnnotations;
using KokaarCis.Utility.Helpers;

namespace KokaarCis.Domain.Assemblers
{
    public class LandTitleDto : BaseDto<int>
    {
        [Required(ErrorMessage = "Le numéro est obligatoire;")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Le propriétaire est obligatoire;")]
        public string Owner { get; set; }

        [Required(ErrorMessage = "La superficie est obligatoire;")]
        public double? Surface { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "La localité est obligatoire;")]
        public int? LocalityId { get; set; }
        public LocalityDto Locality { get; set; }

        public string DisplayText
        {
            get
            {
                if (Locality != null)
                    return $"{Number ?? ""} - {Locality.Name ?? ""} - {Owner ?? ""}".ToTitleCase();

                return $"{Number ?? ""} - {Owner ?? ""}".ToTitleCase();
            }
        }
    }
}
