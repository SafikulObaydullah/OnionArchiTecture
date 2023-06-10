using DIFECMS.Domain.Models;

namespace DIFECMS.Repository.Contracts
{
    public interface ICaseListRepository
    {
        public IEnumerable<CaseList> Get(CaseListSearch caseListSearch);
        public IEnumerable<CaseList> GetTotalUpcomingData(int UserId, int OfficeId);
        public IEnumerable<CaseList> GethearingPendingData(int UserId, int OfficeId);
        public IEnumerable<CaseList> GetCaseActivityUpdatePendingData(int UserId, int OfficeId);
        public IEnumerable<CaseList> GetMyUpcomingData(int UserId, int OfficeId);
    }
}
