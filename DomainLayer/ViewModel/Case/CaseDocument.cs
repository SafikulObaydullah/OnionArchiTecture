using System;

namespace DomainLayer.ViewModel
{
    public class CaseDocument
    {
        public int id { get; set; }
        public int caseId { get; set; }
        public int doctypeid { get; set; }
        public string docTypeName { get; set; }
        public string filetype { get; set; }
        public string encryptionkey { get; set; }
        public string description { get; set; }
        public DateTime issuedate { get; set; }
        public int? Creator { get; set; }
        public int saveType { get; set; }
    }
}
