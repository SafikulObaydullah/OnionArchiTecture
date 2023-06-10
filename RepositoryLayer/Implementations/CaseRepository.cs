using DIFECMS.Common;
using DIFECMS.Domain;
using DIFECMS.Domain.Models;
using DIFECMS.Domain.ViewModel;
using   DomainLayer.ViewModel;
using DIFECMS.Domain.ViewModel.Dashboard;
using DIFECMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.Data.SqlClient;

namespace DIFECMS.Repository.Implementations
{
    public class CaseRepository : ICaseRepository
    {
        private readonly DCMSDBContext _db;

        public CaseRepository(DCMSDBContext db)
        {
            _db = db;
        }
        public SaveVM Save(Case caseInfo)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = caseInfo.ID };
                var CourtTypeID = new SqlParameter { ParameterName = "CourtTypeID", Value = caseInfo.CourtTypeID };
                var CourtID = new SqlParameter { ParameterName = "CourtID", Value = caseInfo.CourtID };
                var CaseCategoryID = new SqlParameter { ParameterName = "CaseCategoryID", Value = caseInfo.CaseCategoryID };
                var CaseNatureID = new SqlParameter { ParameterName = "CaseNatureID", Value = caseInfo.CaseNatureID };
                var CaseStatusID = new SqlParameter { ParameterName = "CaseStatusID", Value = caseInfo.CaseStatusID };
                var CasePriorityID = new SqlParameter { ParameterName = "CasePriorityID", Value = caseInfo.CasePriorityID };
                var CaseTypeID = new SqlParameter { ParameterName = "CaseTypeID", Value = caseInfo.CaseTypeID };
                var ConcernedOfficeID = new SqlParameter
                {
                    ParameterName = "ConcernedOfficeID",
                    Value = caseInfo.ConcernedOfficeID == 0 ? DBNull.Value : caseInfo.ConcernedOfficeID
                };
                var ConcernedPersonID = new SqlParameter { ParameterName = "ConcernedPersonID", Value = caseInfo.ConcernedPersonID };
                var CaseNo = new SqlParameter
                {
                    ParameterName = "CaseNo",
                    Value = caseInfo.CaseNo == null ? DBNull.Value : caseInfo.CaseNo
                };
                var CaseSubject = new SqlParameter
                {
                    ParameterName = "CaseSubject",
                    Value = caseInfo.CaseSubject == null ? DBNull.Value : caseInfo.CaseSubject
                };
                var Year = new SqlParameter
                {
                    ParameterName = "Year",
                    Value = caseInfo.Year
                };
                var IssueDate = new SqlParameter
                {
                    ParameterName = "IssueDate",
                    Value = caseInfo.IssueDate
                };

                var CasePetitioner = new SqlParameter
                {
                    ParameterName = "CasePetitioner",
                    Value = caseInfo.CasePetitioner == null ? DBNull.Value : caseInfo.CasePetitioner
                };
                var CaseDescription = new SqlParameter
                {
                    ParameterName = "CaseDescription",
                    Value = caseInfo.CaseDescription == null ? DBNull.Value : caseInfo.CaseDescription
                };
                var PrincipalRespondent = new SqlParameter
                {
                    ParameterName = "PrincipalRespondent",
                    Value = caseInfo.PrincipalRespondent == null ? DBNull.Value : caseInfo.PrincipalRespondent
                };
                var OtherRespondent = new SqlParameter
                {
                    ParameterName = "OtherRespondent",
                    Value = caseInfo.OtherRespondent == null ? DBNull.Value : caseInfo.OtherRespondent
                };
                var GovernmentLawyer = new SqlParameter
                {
                    ParameterName = "GovernmentLawyer",
                    Value = caseInfo.GovernmentLawyer == null ? DBNull.Value : caseInfo.GovernmentLawyer
                };
                var ReferenceCaseNo = new SqlParameter
                {
                    ParameterName = "ReferenceCaseNo",
                    Value = caseInfo.ReferenceCaseNo == null ? DBNull.Value : caseInfo.ReferenceCaseNo
                };
                var BackgroundOfCase = new SqlParameter
                {
                    ParameterName = "BackgroundOfCase",
                    Value = caseInfo.BackgroundOfCase == null ? DBNull.Value : caseInfo.BackgroundOfCase
                };
                var NextHearingDate = new SqlParameter
                {
                    ParameterName = "NextHearingDate",
                    Value = caseInfo.NextHearingDescription == null ? DBNull.Value : caseInfo.NextHearingDescription
                };

                var NextHearingDescription = new SqlParameter
                {
                    ParameterName = "NextHearingDescription",
                    Value = caseInfo.NextHearingDescription == null ? DBNull.Value : caseInfo.NextHearingDescription
                };
                var CaseSection = new SqlParameter
                {
                    ParameterName = "CaseSection",
                    Value = caseInfo.CaseSection == null ? DBNull.Value : caseInfo.CaseSection
                };
                var IsDifeRespondent = new SqlParameter { ParameterName = "isDifeRespondent", Value = caseInfo.IsDifeRespondent };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = caseInfo.Creator };

                string SP = "InsertUpdateCaseInfo_sp " + caseInfo.ID + "," + caseInfo.CourtTypeID + "," + caseInfo.CourtID + ", " + caseInfo.CaseCategoryID + "," + caseInfo.CaseNatureID + ", " + caseInfo.CaseStatusID + ", " + caseInfo.CasePriorityID + "" +
                    ", " + caseInfo.CaseTypeID + "," + caseInfo.ConcernedOfficeID + ", " + caseInfo.ConcernedPersonID + ", N'" + caseInfo.CaseNo + "', N'" + caseInfo.CaseSubject + "', " + caseInfo.Year + ", '" + caseInfo.IssueDate + "', N'" + caseInfo.CasePetitioner + "'" +
                    ",N'" + caseInfo.CaseDescription + "', N'" + caseInfo.PrincipalRespondent + "',N'" + caseInfo.OtherRespondent + "', " + caseInfo.IsDifeRespondent + ", N'" + caseInfo.GovernmentLawyer + "', N'" + caseInfo.ReferenceCaseNo + "', N'" + caseInfo.BackgroundOfCase + "', " + caseInfo.Creator + "" +
                    ", '" + caseInfo.NextHearingDate + "', N'" + caseInfo.NextHearingDescription + "',N'" + caseInfo.CaseSection + "'";

                var result = _db.Database.SqlQuery<SaveVM>(SP).FirstOrDefault();

                //var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateCaseInfo_sp  @ID,@CourtTypeID,@CourtID," +
                //    "@CaseCategoryID,@CaseNatureID,@CaseStatusID,@CasePriorityID,@CaseTypeID,@ConcernedOfficeID," +
                //    "@ConcernedPersonID,@CaseNo,@CaseSubject,@Year,@IssueDate,@CasePetitioner,@CaseDescription,@PrincipalRespondent," +
                //    "@OtherRespondent,@IsDifeRespondent,@GovernmentLawyer,@ReferenceCaseNo,@BackgroundOfCase, @Creator, @NextHearingDate, @NextHearingDescription",
                //    ID, CourtTypeID, CourtID, CaseCategoryID, CaseNatureID, CaseStatusID, CasePriorityID, CaseTypeID,
                //    ConcernedOfficeID, ConcernedPersonID, CaseNo, CaseSubject, Year, IssueDate, CasePetitioner, CaseDescription, PrincipalRespondent,
                //    OtherRespondent, IsDifeRespondent, GovernmentLawyer, ReferenceCaseNo, BackgroundOfCase, Creator, NextHearingDate, NextHearingDescription).FirstOrDefault();

                if (result.IsSuccess == false)
                {
                    result.Code = (int)ProjectCodes.Error;
                }
                else
                {
                    result.Code = (int)ProjectCodes.Success;
                }
                var resultFinal = new SaveVM
                {
                    ID = result.ID,
                    IsSuccess = result.IsSuccess,
                    Code = result.Code,
                    Message = result.Message,
                };

                return resultFinal;
            }
            catch (Exception ex)
            {
                var result = new SaveVM
                {
                    ID = caseInfo.ID,
                    Code = (int)ProjectCodes.Error,
                    Message = ex.Message,
                    IsSuccess = false
                };
                return result;
            }
        }
        public SaveVM SaveCaseDocumentsData(CaseDocument o)
        {
            try
            {
                var SP = "CaseDocument_t_Insert_Update_SP " + o.id + "," + o.caseId + "," + o.doctypeid + ",'" + o.filetype + "','" + o.encryptionkey + "'," + o.Creator + ",N'" + o.description + "','" + o.issuedate + "'," + o.saveType + "";
                var result = _db.Database.SqlQuery<SaveVM>(SP).FirstOrDefault();
                if (result.IsSuccess == false)
                {
                    result.Code = (int)ProjectCodes.Error;
                }
                else
                {
                    result.Code = (int)ProjectCodes.Success;
                }
                var resultFinal = new SaveVM
                {
                    ID = result.ID,
                    IsSuccess = result.IsSuccess,
                    Code = result.Code,
                    Message = result.Message,
                };

                return resultFinal;
            }
            catch (Exception ex)
            {
                var result = new SaveVM
                {
                    Code = (int)ProjectCodes.Error,
                    Message = ex.Message,
                    IsSuccess = false
                };
                return result;
            }
        }
        public IEnumerable<Case> Get()
        {
            var parms = new SqlParameter("@ID", Convert.Toint(0));
            var results = _db.Database.SqlQuery<Case>("GetCase_sp", parms).ToList();
            return results;
        }
        public IEnumerable<CommonVM> GetCaseDocumentType()
        {
            var results = _db.Database.SqlQuery<CommonVM>("GetCaseDocumentTypes_SP").ToList();
            return results;
        }
        public IEnumerable<CaseDocument> GetCaseDocuments(int CaseId)
        {
            var results = _db.Database.SqlQuery<CaseDocument>("GetDocumentsByCaseId_SP " + CaseId + "").ToList();
            return results;
        }
        public SaveVM DeleteCaseDocumet(int DocumentId, int UserId)
        {
            SaveVM ReturnObject = new SaveVM();
            try
            {
                var SP = "DeleteDocumentInfo_SP " + DocumentId +","+UserId+"";
                ReturnObject = _db.Database.SqlQuery<SaveVM>(SP).FirstOrDefault();
                
            }
            catch(Exception ex)
            {
                ReturnObject.Code= (int)ProjectCodes.Error;
                ReturnObject.Message = ex.ToString();
            }
            return ReturnObject;
           
        }


        public CaseVM GetById(int Id)
        {
            var result = _db.Database.SqlQuery<CaseVM>("GetCaseInfoById_sp " + Id + "").FirstOrDefault();
            return result;
        }
        public CardAndPriorityVM GetCardAndPriority(int Id, int ministryOrDeptId, int office, int UserType)
        {
            var result = _db.Database.SqlQuery<CardAndPriorityVM>("GetDashboardCardData_SP " + Id + "," + ministryOrDeptId + "," + office + "," + UserType + "").FirstOrDefault();
            return result;
        }

        public IEnumerable<CaseReferenceVM> GetReferenceByCaseNo(string caseNo)
        {
            var result = _db.Database.SqlQuery<CaseReferenceVM>("GetCaseIDAndSubjectByCaseNo_sp '" + caseNo + "'").ToList();
            return result;
        }
        public IEnumerable<MonthlyCaseSummary> GetMonthlyCaseSummary(int caseCat, int Creator)
        {
            var result = _db.Database.SqlQuery<MonthlyCaseSummary>("GetMonthlyCaseSummary_SP " + caseCat + ","+Creator+"").ToList();
            return result;
        }
        public IEnumerable<CaseDocument> GetFileEncbasicInfo(int ID)
        {
            var result = _db.Database.SqlQuery<CaseDocument>("GetCaseDocumentsById_SP " + ID + "").ToList();
            return result;
        }
    }
}
