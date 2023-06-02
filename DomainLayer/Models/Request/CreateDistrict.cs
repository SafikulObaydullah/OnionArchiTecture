using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Request
{
   public class CreateDistrict
   {
      public string? Name { get; set; }
      public string? CreatedBy { get; set; } 
      
   }
}
