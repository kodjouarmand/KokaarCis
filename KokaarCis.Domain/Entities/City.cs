﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KokaarCis.Domain.Entities
{
    public class City : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
