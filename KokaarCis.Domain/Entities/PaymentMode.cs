﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KokaarCis.Domain.Entities
{
    public class PaymentMode : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
