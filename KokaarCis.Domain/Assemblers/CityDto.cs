﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KokaarCis.Utility.Helpers;

namespace KokaarCis.Domain.Assemblers
{
    public class CityDto : BaseDto<int>
    {
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        public string DisplayText
        {
            get
            {
                return Name.ToTitleCase();
            }
        }
    }
}
