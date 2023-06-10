﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Report
{
    public class CaseReportVM
    {
        public long ID { get; set; }
        public long CourtTypeID { get; set; }
        public string CourtTypeName { get; set; }
        public long CourtID { get; set; }
        public long CaseCategoryID { get; set; }
        public string CaseCategoryName { get; set; }
        public long CaseNatureID { get; set; }
        public string CaseNatureName { get; set; }
        public long CaseStatusID { get; set; }
        public string CaseStatusName { get; set; }
        public long? CasePriorityID { get; set; }
        public long CaseTypeID { get; set; }
        public string CaseTypeName { get; set; }
        public string CourtName { get; set; }
        public long ConcernedOfficeID { get; set; }
        public string OfficeName { get; set; }
        public long ConcernedPersonID { get; set; }
        public string PersonName { get; set; }
        public string CaseNo { get; set; }
        public string CaseSubject { get; set; }
        public int Year { get; set; }
        public DateTime IssueDate { get; set; }
        public string CasePetitioner { get; set; }
        public string CaseDescription { get; set; }
        public string PrincipalRespondent { get; set; }
        public string OtherRespondent { get; set; }
        public bool IsDifeRespondent { get; set; }
        public string GovernmentLawyer { get; set; }
        public string ReferenceCaseNo { get; set; }
        public string BackgroundOfCase { get; set; }
        public long Creator { get; set; }
        public string CaseNoReference { get; set; }
        public DateTime ReferenceCaseIssueDate { get; set; }
        public string ReferenceCaseSubject { get; set; }
        public string ReferenceCaseBackground { get; set;}
        public string ReferenceCourtName { get; set; }
        
    }
}
