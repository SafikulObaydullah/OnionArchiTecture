using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Configuration
{
    public class CaseActivity
    {
        public int ID { get; set; }
        public int CaseId { get; set; }
        public int ActivityTypeId { get; set; }
        public int ActivityNatureId { get; set; }
        public string? Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public string? NextHearingDate { get; set; }
        public int Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
