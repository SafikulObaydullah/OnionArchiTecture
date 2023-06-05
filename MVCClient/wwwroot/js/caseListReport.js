
var GridData = []


function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}
var CaseNo = getUrlParameter('CaseId');
var Year = getUrlParameter('year');
var CourtTypeID = getUrlParameter('CourtTypeId');
var CaseCategoryID = getUrlParameter('CaseCategory');
var CaseTypeID = getUrlParameter('CaseType');
var CourtID = getUrlParameter('Court');
var ConcernedPersonID = getUrlParameter('ConcPerson');
var ConcernedOfficeID = getUrlParameter('ConcOffice');
var IssueDateFrom = getUrlParameter('issueDateFrom');
var IssueDateTo = getUrlParameter('issueDateTo');

$(document).ready(function () {
    CaseNo == undefined ? 0 : CaseNo;
    CaseReportDetails();

});


function CaseReportDetails() {
    var o = new Object();
    o.CaseNo = CaseNo;
    o.Year = Year;
    o.CourtTypeId = CourtTypeID;
    o.CaseCategoryID = CaseCategoryID;
    o.CaseTypeID = CaseTypeID;
    o.CourtID = CourtID;
    o.ConcernedPersonID = ConcernedPersonID;
    o.ConcernedOfficeID = ConcernedOfficeID;
    o.IssueDateFrom = IssueDateFrom;
    o.IssueDateTo = IssueDateTo;
    console.log(o)
    /*blockUI()*/
    $.ajax({
        url: "/Report/ReportSearchResult",
        method: "GET",
        dataType: "json",
        data: o,
        success: function (data) {
            console.log(data);
            /*unblockUI()*/
            GridData = data;
            if (GridData.length > 0) {
                BindData();
            }
        },
        error: function (er) {
            console.log(er)
        }
    })
}
function BindData() {
    var result = GridData;
    $("#caseListReport tbody").empty();
    var sl = 1;
    for (var i = 0; i < result.length; i++) {
        var html = "<tr><td style='text-align:center; ' >" + sl + "</td>" +
            "<td style='width:10%;text-align:left;' > " + result[i].nameE + "</td> " +
            "<td style='width:10%;text-align:left;'>" + result[i].caseNo + "</td>" +
            " <td style='width:30%;text-align:left;'> " + result[i].caseSubject + "</td>" +
            " <td style='width:40%;text-align:left;word-wrap: break-word;overflow-wrap:anywhere' >" + result[i].caseDescription + "</td>" +
            "</tr>";
        $("#caseListReport tbody").append(html)
        sl = sl + 1;
    }
}
