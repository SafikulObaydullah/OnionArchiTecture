
$(document).ready(function () {
    $('#ex0').kendoExpansionPanel({
        title: 'Search Panel',
        expanded: true
    });
});
function DownloadCaseDocumentById(id) {
    $.ajax({
        url: "/Case/DownloadCaseDocumentById?ID=" + id,
        method: "GET",
        dataType: 'json',
        success: function (data) {
            console.log(data);
            debugger
            var link = document.createElement('a');
            link.href = "/TemporaryFileStorage/CaseDocFiles/Enc_Case_" + data[0].caseId + "_" + data[0].doctypeid + "_" + data[0].id + data[0].filetype;
            link.download = data[0].caseId + ' ' +data[0].docTypeName.trim() + ' (' + (data[0].issuedate == "0001-01-01T00_00_00" ? "" : moment(data[0].issuedate).format('LL')) + ')' + data[0].filetype;
            link.click();
            link.remove();
        }
    });
}