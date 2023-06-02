using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
   public class CustomerInfo 
   {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PurchasesProduct { get; set; }
        public string PaymentType { get; set; }
   }
}
