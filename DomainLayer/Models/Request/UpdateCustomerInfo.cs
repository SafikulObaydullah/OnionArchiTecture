using System;

namespace DomainLayer.Models.Request
{
    public class UpdateCustomerInfo
    {
      public int Id { get; set; }
      public string CustomerName { get; set; }
      public string PurchasesProduct { get; set; }
      public string PaymentType { get; set; }
   }
}