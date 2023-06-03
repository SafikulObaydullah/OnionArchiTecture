using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer.Models
{
   public class CustomerInfo 
   {
        public int Id { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
         [Required]
         [StringLength(50)]
         [Column("PurchasesProduct")]
         [Display(Name = "Purchases Product")]
        public string PurchasesProduct { get; set; }
        public string PaymentType { get; set; }
   }
}
