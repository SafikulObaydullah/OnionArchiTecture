using DomainLayer.Models.Accounts;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Dashboard;
using System.Collections.Generic;

namespace RepositoryLayer.Contracts
{
    public interface ICaseRepository
    {
        public SaveVM Save(Case caseInfo);
        public SaveVM SaveCaseDocumentsData(CaseDocument caseInfo);
        public SaveVM DeleteCaseDocumet(int DocumentId, int UserId);
        public IEnumerable<Case> Get();
        public IEnumerable<CommonVM> GetCaseDocumentType();
        public IEnumerable<CaseDocument> GetCaseDocuments(int CaseId);
        public CaseVM GetById(int Id);
        public CardAndPriorityVM GetCardAndPriority(int Id, int ministryOrDeptId, int office, int UserType);
        public IEnumerable<CaseReferenceVM> GetReferenceByCaseNo(string caseNo);
        public IEnumerable<MonthlyCaseSummary> GetMonthlyCaseSummary(int caseCat, int Creator);
        public IEnumerable<CaseDocument> GetFileEncbasicInfo(int ID);
    }
}
