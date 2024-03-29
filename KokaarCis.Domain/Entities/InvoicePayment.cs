﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KokaarCis.Domain.Entities
{
    public class InvoicePayment : BaseEntity<int>
    {
        [NotMapped]
        public string Number { get; set; }
        [Required]
        public double AmountPaid { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string TransactionNumber { get; set; }

        [Required]
        public int InvoiceHeaderId { get; set; }
        [ForeignKey("InvoiceHeaderId")]
        public InvoiceHeader InvoiceHeader { get; set; }

        [Required]
        public int PaymentModeId { get; set; }
        [ForeignKey("PaymentModeId")]
        public PaymentMode PaymentMode { get; set; }
    }
}
