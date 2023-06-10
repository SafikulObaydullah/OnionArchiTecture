using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Report
{
    public class OfficeAndCourtWiseReportVM
    {
        public int IssueYearFrom { get; set; }
        public int IssueYearTo { get; set; }
        public int OfficeId { get; set; }
        public int MinistryOrDepartmentId { get; set; }
        public int CourtTypeId { get; set; }
        public int caseStatus { get; set; }

    }
}
