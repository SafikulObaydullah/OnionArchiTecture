using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFECMS.Domain.ViewModel.Configuration.CaseActivity
{
    public class CaseActivityVM
    {
        public int Id { get; set; }
        public string GovernmentLawyer { get; set; }
        public string CaseType { get; set; }
        public int CaseId { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public int ActivityNatureId { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime? NextHearingDate { get; set; }
    }
}
