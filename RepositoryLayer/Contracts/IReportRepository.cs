using DomainLayer.Models.Accounts;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Report;
using System.Collections.Generic;
using System.Data;

namespace RepositoryLayer.Contracts
{
    public interface IReportRepository
    {
        public CaseReportVM GetCaseReport(int id);
        public DataTable GetOfficeAndCourtWiseReport(OfficeAndCourtWiseReportVM officeAndCourtWiseReportVM);
        public List<CaseList> GetOfficeAndCourtWiseReportDetail(OfficeAndCourtWiseReportVM officeAndCourtWiseReportVM);
        public IEnumerable<CaseList> GetCaseList(CaseListSearch o);
    }
}
