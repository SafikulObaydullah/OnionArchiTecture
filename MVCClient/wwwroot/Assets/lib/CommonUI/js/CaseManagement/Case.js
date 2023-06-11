var CasePriorityList = [
    { id: 1, nameE: "High" },
    { id: 2, nameE: "Medium" },
    { id: 3, nameE: "Low" }]

var CourtTypeList = []
var CourtList = []
var CaseCategoryList = []
var CaseTypeList = []
var CaseNatureList = []
var CaseStatusList = []
var OfficeList = []
var ConcernedPersonList = []
var CaseData;
var CaseDataList = []
var documents = [];
var CaseDocuments = [];
var CaseReference = [];
var ConcernedDepartment = [];
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

var CaseId = getUrlParameter('ID');

$(document).ready(function () {
    $("#btnReport").hide();

    BindInitialDDL();
    CaseId == undefined ? 0 : CaseId;
    CaseDropdownsLoad(CaseId);
    $('#issueDate').val('');
    $('#txtNextHearingDate').val('');
    $(".Kdatepicker").bind("focus", function () {
        $(this).data("kendoDatePicker").open();
    });
    $("#ddlCaseRefNo").kendoAutoComplete({
        dataTextField: "subject",
        dataValueField: "caseId",
        minLength: 1,
        dataSource: {
            type: "json",
            serverFiltering: true,
            transport: {
                read:
                    function (options) {
                        console.log(options)
                        $.ajax({
                            url: '/Case/GetCaseIDAndSubjectByCaseNo',
                            contentType: 'application/json',
                            data: { caseNo: (options.data.filter.filters.length == 0 ? '' : options.data.filter.filters[0].value) },
                            type: "Get",
                            xhrFields: {
                                withCredentials: true
                            },
                            crossDomain: true,
                            success: function (result) {
                                CaseReference = [];
                                CaseReference = result;
                                if (CaseReference == null || CaseReference == 'null') {
                                    let arrayObj = [{ "subject": "No Data Found" }];
                                    CaseReference = arrayObj;
                                }
                                options.success(CaseReference);
                            }
                        });
                    }
            }
        },
        change: function (e) {
            /* The result can be observed in the DevTools(F12) console of the browser. */
            if (this.value() == '') {
                $("#referenceInfo").html("");
                console.log("Empty")
            }
            $("#referenceInfo").text("Subject: " + this.value());
            $("#caseReferenceID").html(this.value());

        }
    });
})

function onSelectCase(e) {
    var id = this.element[0].id;//.split('_')[1]
    this.clearAllFiles()
    var fileInfo = e.files[0];
    var wrapper = this.wrapper;

    setTimeout(function () {
        addPreviewDocImage(fileInfo, wrapper, id);
    });
}

function addPreviewDocImage(file, wrapper, id) {
    console.log(file);
    if (file.extension.toLowerCase() != ".png" && file.extension.toLowerCase() != ".jpeg" && file.extension.toLowerCase() != ".jpg" && file.extension.toLowerCase() != ".pdf") {
        kendo.alert('Only png, jpg, jpeg, pdf File supported');
        var upload = $("#" + id).data("kendoUpload");
        upload.removeAllFiles();
        return;
    }
    var raw = file.rawFile;

    var reader = new FileReader();

    if (raw) {
        reader.onloadend = function (e) {

            var image = new Image();

            //Set the Base64 string return from FileReader as source.
            image.src = e.target.result;

            //Validate the File Height and Width.
            image.onload = function () {
                var height = this.height;
                var width = this.width;


                if (width <= 1080) {
                    var preview = $("<img class='image-preview'>").attr("src", this.result);

                    wrapper.find(".k-file[data-uid='" + file.uid + "'] .k-file-group-wrapper")
                        .replaceWith(preview);
                }
                else {
                    kendo.alert('Image Size (Max-Width: 1080 pixels)');
                    var upload = $("#" + id).data("kendoUpload");
                    upload.removeAllFiles();
                    return;
                }


            };

        };

        reader.readAsDataURL(raw);
    }
}

function onSelectStepper(e) {
    var index = e.step.options.index;
    if (index == 0) {
        $('#generalInfo').show();
        $('#attachments').hide();
    }
    else if (index == 1) {
        $('#generalInfo').hide();
        $('#attachments').show();
    }

}

function BindInitialDDL() {
    $("#tabstrip").kendoTabStrip({
        select: onTabSelect, change: function (x) {
            $('#tabstripofElements-1').css('height', '100%')
            $('#tabstripofElements-2').css('height', '100%')
        }
    });

    tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
    tabStrip.select(0);

    $("#caseDocfiles").kendoUpload({
        validation: {
            allowedExtensions: [".pdf", ".PDF", ".png", ".PNG", ".jpg", "jpeg", ".JPG", "JPEG"],
            maxFileSize: 4194304
        },
        async: {
            autoUpload: true
        },
        select: onSelectCase,
    });

    $("#ddlCourtType").kendoComboBox({
        placeholder: 'Select Court Type',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        change: function () {
            if (this.dataItem() == undefined) {
                $("#ddlCourt").data('kendoComboBox').dataSource.data([]);
                $("#ddlCourt").data('kendoComboBox').value('');
                return;
            }
            var id = this.dataItem().id;
            var FilterData = _.filter(CourtList, function (item) { return item.courtTypeID == id });
            $("#ddlCourt").data('kendoComboBox').dataSource.data([]);
            $("#ddlCourt").data('kendoComboBox').dataSource.data(FilterData);
            $("#ddlCourt").data('kendoComboBox').focus();
            $("#ddlCourt").data('kendoComboBox').open();
            var FilterData2 = _.filter(CaseCategoryList, function (item) { return item.courtTypeID == id });
            $("#ddlCaseCategory").data('kendoComboBox').dataSource.data([]);
            $("#ddlCaseCategory").data('kendoComboBox').value('');
            $("#ddlCaseCategory").data('kendoComboBox').dataSource.data(FilterData2);
        }
    });
    $("#ddlCourt").kendoComboBox({
        placeholder: 'Select Court..',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        //change: function () {
        //    if (this.dataItem() == undefined) {
        //        $("#ddlCaseCategory").data('kendoComboBox').dataSource.data([]);
        //        $("#ddlCaseCategory").data('kendoComboBox').value('');
        //        return;
        //    }
        //    var id = this.dataItem().id;
        //    var FilterData = _.filter(CaseCategoryList, function (item) { return item.typeId == id });
        //    $("#ddlCaseCategory").data('kendoComboBox').dataSource.data([]);
        //    $("#ddlCaseCategory").data('kendoComboBox').dataSource.data(FilterData);
        //}
    });
    $("#ddlConcernedDepartment").kendoComboBox({
        placeholder: 'Select Concerned Department',
        dataTextField: "ministryOrDepartmentName",
        dataValueField: "ministryOrDepartmentId",
        dataSource: [],
        filter: "contains",
        change: function () {

            if (this.dataItem() == undefined) {
                $("#ddlConOff").data('kendoComboBox').dataSource.data([]);
                $("#ddlConOff").data('kendoComboBox').value('');
                return;
            }
            var id = this.dataItem().ministryOrDepartmentId;
            var FilterData = _.filter(OfficeAndDepartmentList, function (item) { return item.ministryOrDepartmentId == id });
            $("#ddlConOff").data('kendoComboBox').dataSource.data([]);
            $("#ddlConOff").data('kendoComboBox').dataSource.data(FilterData);
            $("#ddlConOff").data('kendoComboBox').focus();
            $("#ddlConOff").data('kendoComboBox').open();
        }
    });

    $("#ddlCaseCategory").kendoComboBox({
        placeholder: 'Select Case Category',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        change: function () {
            if (this.dataItem() == undefined) {
                $("#ddlCaseType").data('kendoComboBox').dataSource.data([]);
                $("#ddlCaseType").data('kendoComboBox').value('');
                return;
            }
            var id = this.dataItem().id;
            var FilterData = _.filter(CaseTypeList, function (item) { return item.caseCategoryID == id });
            $("#ddlCaseType").data('kendoComboBox').dataSource.data([]);
            $("#ddlCaseType").data('kendoComboBox').dataSource.data(FilterData);
            $("#ddlCaseType").data('kendoComboBox').focus();
            $("#ddlCaseType").data('kendoComboBox').open();
        }
    });
    $("#ddlCaseType").kendoComboBox({
        placeholder: 'Select Case Type',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains"
    });
    $("#ddlCasePriority").kendoComboBox({
        placeholder: 'Select Case Priority',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains"
    });
    $("#ddlCaseNature").kendoComboBox({
        placeholder: 'Select Case Nature',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains"
    });
    $("#ddlCaseStatus").kendoComboBox({
        placeholder: 'Select Case Status',
        dataTextField: "nameE",
        dataValueField: "id",
        dataSource: [],
        filter: "contains"
    });
    $("#ddlConOff").kendoComboBox({
        placeholder: 'Select Concerned Office',
        dataTextField: "officeName",
        dataValueField: "officeId",
        dataSource: [],
        filter: "contains"
    });
    $("#ddlConPer").kendoComboBox({
        placeholder: 'Select Concerned Person',
        dataTextField: "concernedPersonOffice",
        dataValueField: "id",
        dataSource: [],
        filter: "contains"
    });
    $("#ddlDocumentType").kendoComboBox({
        placeholder: 'Select Document Type',
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains"
    });
    //$("#ddlCaseRefNo").kendoComboBox({
    //    placeholder: 'Select Case Ref',
    //    dataTextField: "name",
    //    dataValueField: "id",
    //    dataSource: [],
    //    filter: "contains"
    //});
}

function CaseDropdownsLoad(id) {
    blockUI();
    $.ajax({
        url: "/Case/GetAllCaseData?id=" + id,
        method: "GET",
        dataType: "json",
        success: function (data) {
            unblockUI();

            CourtTypeList = data.courtType;
            $("#ddlCourtType").data('kendoComboBox').dataSource.data(CourtTypeList);

            OfficeList = data.office;
            $("#ddlConOff").data('kendoComboBox').dataSource.data(OfficeList);

            CourtList = data.court;
            //$("#ddlCourt").data('kendoComboBox').dataSource.data(CourtList);

            CaseCategoryList = data.caseCategory;

            CaseNatureList = data.caseNature;
            $("#ddlCaseNature").data('kendoComboBox').dataSource.data(CaseNatureList);

            CaseStatusList = data.caseStatus;
            $("#ddlCaseStatus").data('kendoComboBox').dataSource.data(CaseStatusList);

            CaseTypeList = data.caseType
            //$("#ddlCaseType").data('kendoComboBox').dataSource.data(CaseTypeList);

            ConcernedPersonList = data.concernedPerson
            for (var i = 0; i < ConcernedPersonList.length; i++) {
                ConcernedPersonList[i].concernedPersonOffice = ConcernedPersonList[i].name + " (" + ConcernedPersonList[i].officeName + ")";
            };
            $("#ddlConPer").data('kendoComboBox').dataSource.data(ConcernedPersonList);


            $("#ddlCasePriority").data('kendoComboBox').dataSource.data(CasePriorityList);

            OfficeAndDepartmentList = data.officeAndMinistryOrDepartment;
            var filterDepartmentData = _.uniq(OfficeAndDepartmentList, function (itm) { return itm.ministryOrDepartmentId, itm.ministryOrDepartmentName });
            $('#ddlConcernedDepartment').data('kendoComboBox').dataSource.data(filterDepartmentData)

            documents = data.document;
            $('#ddlDocumentType').data('kendoComboBox').dataSource.data(documents)

            CaseData = data.casedata;
            CaseDocuments = data.caseDocuments;

            if (CaseData != null) {
                CaseDataList.push(CaseData)
            }

            if (CaseDataList.length > 0) {
                BindParentData();
            }
            $("#gridCaseDocuments").hide();
            if (CaseDocuments.length > 0) {
                $("#gridCaseDocuments").show();
                BindDocumentGrid();
            }
         
        },
        error: function (jqXHR, textStatus, errorThrown) {
            unblockUI();
            console.log("Error:", textStatus, errorThrown);
        }
    })
}



function onTabSelect(e) {

    console.log("Selected: " + $(e.item).find("> .k-link").text());
    $('#' + this.element[0].id).css('height', '100%');

    if (e.item.id == 'tabstrip-tab-2') {
        if ($('#spanParentID').html() <= 0) {
            popupNotification.warning('Please search a case and then upload documents.');
            const myTabTimeout = setTimeout(myGreeting, 5000);
        }
    }
}


function myTabStopFunction() {
    var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
    tabStrip.select(tabStrip.tabGroup.children("li").eq(0));
    clearTimeout(myTabTimeout);
}
function Save() {
    var o = new Object();
    var validate = true;
    var regExp = /\(([^)]+)\)/;
    var matches = regExp.exec($('#ddlCaseRefNo').val());
    var referenceCaseNo = 0;
    if (matches == null || matches == "" || matches == 0) {
        referenceCaseNo = 0;
    }
    else {
        referenceCaseNo = matches[1];
    }

    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.CaseNo = $('#caseNo').val();
        o.year = moment($('#issueDate').val()).format('YYYY');
        o.courtTypeID = $('#ddlCourtType').data('kendoComboBox').value();
        o.courtID = $('#ddlCourt').data('kendoComboBox').value();
        o.caseCategoryID = $('#ddlCaseCategory').data('kendoComboBox').value();
        o.caseTypeID = $('#ddlCaseType').data('kendoComboBox').value();
        o.caseNatureID = $('#ddlCaseNature').data('kendoComboBox').value();
        o.caseStatusID = $('#ddlCaseStatus').data('kendoComboBox').value();
        o.caseSubject = $('#caseSubject').val();
        o.casePriorityID = $("#ddlCasePriority").data('kendoComboBox').value();
        o.issueDate = $('#issueDate').val() == "" ? "" : moment($('#issueDate').val()).format('YYYY-MM-DD');
        o.casePetitioner = $('#casePetitioner').val();
        o.caseDescription = $('#caseDescription').val();
        o.principalRespondent = $('#principalRespondent').val();
        o.otherRespondent = $('#otherRespondent').val();
        o.concernedOfficeID =$('#ddlConOff').data('kendoComboBox').value();
        o.concernedPersonID =$('#ddlConPer').data('kendoComboBox').value();
        o.governmentLawyer = $('#governmentLawyer').val();
        o.referenceCaseNo = referenceCaseNo;
        o.backgroundOfCase = $('#backgroundOfCase').val();
        o.isDifeRespondent = $('#isDifeRespondent').is(':checked') ? true : false;
        o.nextHearingDate = $('#txtNextHearingDate').val() == "" ? "" : moment($('#txtNextHearingDate').val()).format('YYYY-MM-DD');
        o.nextHearingDescription = $('#txtNextHearingDescription').val();
        o.caseSection = $('#txtCaseSection').val();
        o.creator = o.id;
        blockUI();
        $.ajax({
            url: "/Case/CaseSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                unblockUI();

                if (data.code == 200) {
                    $('#spanParentID').html(data.id)
                    kendo.confirm(data.message)
                        .done(function () {

                        })
                        .fail(function () {

                        });

                } else {
                    popupNotification.error(data.message);
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                unblockUI();
                popupNotification.error(data.message);
            }
        });
        $('#mdlUserReg').modal('hide')
    }
}

function Validate() {

    if ($('#issueDate').val() == "") {
        $('#issueDate').focus();
        popupNotification.warning('Please select Year');
        return false;
    }
    if ($('#ddlCourtType').data('kendoComboBox').value() == "" || $("#ddlCourtType").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCourtType').focus();
        popupNotification.warning('Please input court type');
        return false;
    }
    if ($('#ddlCourt').data('kendoComboBox').value() == "" || $("#ddlCourt").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCourt').focus();
        popupNotification.warning('Please input court');
        return false;
    }
    if ($('#ddlCaseCategory').data('kendoComboBox').value() == "" || $("#ddlCaseCategory").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCaseCategory').focus();
        popupNotification.warning('Please input valid case category');
        return false;
    }
    if ($('#ddlCaseType').data('kendoComboBox').value() == "" || $("#ddlCaseType").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCaseType').focus();
        popupNotification.warning('Please input valid case type');
        return false;
    }
    if ($('#ddlCaseNature').data('kendoComboBox').value() == "" || $("#ddlCaseNature").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCaseNature').focus();
        popupNotification.warning('Please input valid case nature');
        return false;
    }
    if ($('#ddlCaseStatus').data('kendoComboBox').value() == "" || $("#ddlCaseStatus").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCaseStatus').focus();
        popupNotification.warning('Please input valid case status');
        return false;
    }
    if ($('#caseSubject').val() == "") {
        $('#caseSubject').focus();
        popupNotification.warning('Please input case subject');
        return false;
    }
    if ($('#ddlCasePriority').data('kendoComboBox').value() == "" || $("#ddlCasePriority").data('kendoComboBox').selectedIndex == -1) {
        $('#ddlCasePriority').focus();
        popupNotification.warning('Please input valid case priority');
        return false;
    }
    if ($('#issueDate').val() == "") {
        $('#issueDate').focus();
        popupNotification.warning('Please input issue date');
        return false;
    }
    if ($('#casePetitioner').val() == "") {
        $('#casePetitioner').focus();
        popupNotification.warning('Please input case petitioner');
        return false;
    }
    if ($('#caseDescription').val() == "") {
        $('#caseDescription').focus();
        popupNotification.warning('Please input case description');
        return false;
    }
    if ($('#principalRespondent').val() == "") {
        $('#principalRespondent').focus();
        popupNotification.warning('Please input respondent name');
        return false;
    }
    if ($('#principalRespondent').val() == "") {
        $('#principalRespondent').focus();
        popupNotification.warning('Please input respondent name');
        return false;
    }
    if ($('#txtCaseSection').val() == "") {
        $('#txtCaseSection').focus();
        popupNotification.warning('Please input case Section');
        return false;
    }
    return true;

}

function ClearFields() {
    $('#spanParentID').html(0);
    $('#caseNo').val("");
    $("#ddlCourtType").data('kendoComboBox').value('');
    $("#ddlCourt").data('kendoComboBox').value('');
    $("#ddlCaseCategory").data('kendoComboBox').value('');
    $("#ddlCaseType").data('kendoComboBox').value('');
    $("#ddlCaseNature").data('kendoComboBox').value('');
    $("#ddlCaseStatus").data('kendoComboBox').value('');
    $("#ddlCasePriority").data('kendoComboBox').value('');
    $('#caseSubject').val("");
    $('#issueDate').val("");
    $('#casePetitioner').val("");
    $('#caseDescription').val("");
    $('#principalRespondent').val("");
    $('#otherRespondent').val("");
    $("#ddlConOff").data('kendoComboBox').value('');
    $("#ddlConPer").data('kendoComboBox').value('');
    $('#governmentLawyer').val("");
    $('#refCaseNo').val("");
    $('#backgroundOfCase').val("");
    $('#txtCaseSection').val("");
}

function BindParentData() {
    $('#spanParentID').html(CaseDataList[0].id)
    $('#caseNo').val(CaseDataList[0].caseNo)
    //$('#year').val(CaseDataList[0].year)
    $("#ddlCourtType").data('kendoComboBox').value(CaseDataList[0].courtTypeID);

    var FilterData = _.filter(CourtList, function (item) { return item.courtTypeID == CaseDataList[0].courtTypeID });
    $("#ddlCourt").data('kendoComboBox').dataSource.data([]);
    $("#ddlCourt").data('kendoComboBox').dataSource.data(FilterData);
    $("#ddlCourt").data('kendoComboBox').value(CaseDataList[0].courtID);

    var FilterData2 = _.filter(CaseCategoryList, function (item) { return item.courtTypeID == CaseDataList[0].courtTypeID });
    $("#ddlCaseCategory").data('kendoComboBox').dataSource.data([]);
    $("#ddlCaseCategory").data('kendoComboBox').value('');
    $("#ddlCaseCategory").data('kendoComboBox').dataSource.data(FilterData2);
    $("#ddlCaseCategory").data('kendoComboBox').value(CaseDataList[0].caseCategoryID);


    var FilterData = _.filter(CaseTypeList, function (item) { return item.caseCategoryID == CaseDataList[0].caseCategoryID });
    $("#ddlCaseType").data('kendoComboBox').dataSource.data([]);
    $("#ddlCaseType").data('kendoComboBox').dataSource.data(FilterData);
    $("#ddlCaseType").data('kendoComboBox').value(CaseDataList[0].caseTypeID);
    $("#ddlCaseNature").data('kendoComboBox').value(CaseDataList[0].caseNatureID);
    $("#ddlCaseStatus").data('kendoComboBox').value(CaseDataList[0].caseStatusID);
    $("#ddlCasePriority").data('kendoComboBox').value(CaseDataList[0].casePriorityID);
    $('#caseSubject').val(CaseDataList[0].caseSubject);
    CaseDataList[0].isDifeRespondent == false ? $('#isDifeRespondent').prop('checked', false) : $('#isDifeRespondent').prop('checked', true)
    $('#issueDate').val(moment(CaseDataList[0].issueDate).format('MM/DD/YYYY'));
    $('#casePetitioner').val(CaseDataList[0].casePetitioner);
    $('#caseDescription').val(CaseDataList[0].caseDescription);
    $('#principalRespondent').val(CaseDataList[0].principalRespondent);
    $('#otherRespondent').val(CaseDataList[0].otherRespondent);
    $("#ddlConcernedDepartment").data('kendoComboBox').value(CaseDataList[0].concernedDepartmentID);
    var FilterData = _.filter(OfficeAndDepartmentList, function (item) { return item.ministryOrDepartmentId == CaseDataList[0].concernedDepartmentID });
    $("#ddlConOff").data('kendoComboBox').dataSource.data([]);
    $("#ddlConOff").data('kendoComboBox').dataSource.data(FilterData);
    $("#ddlConOff").data('kendoComboBox').value(CaseDataList[0].concernedOfficeID);
    $("#ddlConPer").data('kendoComboBox').value(CaseDataList[0].concernedPersonID);
    $('#governmentLawyer').val(CaseDataList[0].governmentLawyer);
    $('#ddlCaseRefNo').val(CaseDataList[0].caseReference);
    $('#backgroundOfCase').val(CaseDataList[0].backgroundOfCase);
    $('#txtNextHearingDate').val(CaseDataList[0].nextHearingDate == "0001-01-01T00:00:00" ? "" : moment(CaseDataList[0].nextHearingDate).format('MM/DD/YYYY'));
    $('#txtNextHearingDescription').val(CaseDataList[0].nextHearingDescription);
    $('#txtNextHearingDate').attr('disabled', 'disabled');
    $('#txtNextHearingDescription').attr('disabled', 'disabled');
    $('#txtCaseSection').val(CaseDataList[0].caseSection);

    if (CaseDocuments.length > 0) {
        for (var i = 0; i < CaseDocuments.length; i++) {
            $('#txtDescription_' + CaseDocuments[i].doctypeid).val(CaseDocuments[i].description);
            $('#btnViewDoc_' + CaseDocuments[i].doctypeid).show();
        }
    }
    $("#btnReport").show();
}
function Report() {
    var id = $('#spanParentID').html()
    var url = '/Report/Index?ID=' + id;
    window.open(url, '_blank');
}
function SaveCaseDocuments() {
    var savedata = new FormData();
    if ($('#spanParentID').html() <= 0) {
        popupNotification.warning('Please search a case and then upload documents.')
        return;
    }
    if ($('#ddlDocumentType').data('kendoComboBox').value() == 0 || $('#ddlDocumentType').data('kendoComboBox').value() == '') {
        popupNotification.warning('Please select document Type.')
        return;
    }
    savedata.append("id", $('#docParentId').html())
    savedata.append("caseId", $('#spanParentID').html())
    savedata.append("doctypeid", $('#ddlDocumentType').data('kendoComboBox').value());
    savedata.append("issuedate", ($('#txtIssueDate').val() == "" ? "" : moment($('#txtIssueDate').val()).format('YYYY-MM-DD')));
    savedata.append("description", $('#txtDocDescription').val());


    var totalFiles = $("#caseDocfiles").data("kendoUpload").getFiles();
    if ($('#docParentId').html() <= 0 && totalFiles.length <= 0) {
        popupNotification.warning('Please upload documents');
        return;
    }
    for (var i = 0; i < totalFiles.length; i++) {
        if (totalFiles[i].extension.toLowerCase() == ".jpg" || totalFiles[i].extension.toLowerCase() == ".jpeg" || totalFiles[i].extension.toLowerCase() == ".png" || totalFiles[i].extension.toLowerCase() == ".pdf") {
            savedata.append($('#ddlDocumentType').data('kendoComboBox').value(), totalFiles[i].rawFile);
        }
        else {
            $("#caseDocfiles").data("kendoUpload").destroy();
            $("#caseDocfiles").kendoUpload();
            popupNotification.warning('Please select .pdf .jpeg, .jpg, .png files only');
            return;
        }
    }

    $.ajax({
        type: "POST",
        url: '/Case/SaveCaseDocumentsData',
        data: savedata,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
            var result = JSON.parse(response);
            console.log(result)
            if (result.statuscode == 302) {
                popupNotification.show(result.data.message, "success");
                CaseDocuments = result.caseDocuments;
                $("#gridCaseDocuments").show()
                BindDocumentGrid();
            }
            else {
                popupNotification.show(result.data.message, "error");
            }
        },
        error: function (error) {
            popupNotification.show('Error while saving data.', "error");
        }
    });
}

function ViewDocuments(id) {

}

function BindDocumentGrid() {
    $("#gridCaseDocuments").kendoGrid({
        dataSource: {
            data: CaseDocuments
        },
        sortable: true,
        columns: [{
            field: "id",
            title: "ID",
            hidden: true
        }, {
            field: "docTypeName",
            title: "Document Name"
           
        }, {
            field: "description",
            title: "Description"
           
        }, {
            template: "#=moment(issuedate).format('LL')#",
            field: "issuedate",
            title: "Issuedate"
           
        }, {
            //template: "<button class='btn btn-info' onclick='EditDocuments(#:id#)'><span class='k-icon k-i-edit'></span></button> &nbsp;&nbsp;" +
            //    "<button class='btn btn-secondary' onclick='DownloadDocuments(#:id#)'><span class='k-icon k-i-download'></span></button>",
            template: "<button class='btn btn-secondary' onclick='DownloadDocuments(#:id#)'><span class='k-icon k-i-download'></span></button>"  + "   " +
                "<button class='btn btn-info' onclick='DeleteDocuments(#:id#)'><span class='fa fa-trash'></span></button> &nbsp;&nbsp;",
            field: "id",
            title: "Action",
            attributes: {
                style: "text-align:center"
            }
           
        }]
    });
}

function DeleteDocuments(id) {
    var dataObject = new Object();
    dataObject.id = id;

    kendo.confirm("Are You Sure want to Delete this data?")
        .done(function () {
            $.ajax({
                type: "GET",
                url: '/Case/DeleteCaseDocument',
                data: dataObject,
                dataType: 'json',
                success: function (response) {
                    var result = JSON.parse(response);
                    console.log(result)
                    if (result.code=="200") {
                        
                        var grid = $("#gridCaseDocuments").data("kendoGrid");
                        var dataItem = grid.dataSource.get(id);
                        var row = grid.tbody.find("tr[data-uid='" + dataItem.uid + "']");
                        grid.removeRow(row);
                    }
                    else {
                        popupNotification.show(result.message, "error");
                    }
                },
                error: function (error) {
                    popupNotification.show('Error while Delete data.', "error");
                }
            });
            console.log("User accepted");
        })
        .fail(function () {
            /* The result can be observed in the DevTools(F12) console of the browser. */
            console.log("User rejected");
        });
}
function EditDocuments(id) {
    var FilterData = _.filter(CaseDocuments, function (item) { return item.id == id });
    if (FilterData.length > 0) {
        $('#docParentId').html(FilterData[0].id);
        $('#ddlDocumentType').data('kendoComboBox').value(FilterData[0].doctypeid);
        $('#txtIssueDate').val(moment(FilterData[0].issuedate).format('MM/DD/YYYY'));
        $('#txtDocDescription').val(FilterData[0].description);
        $('#txtCaseSection').val(FilterData[0].caseSection)
    }

}

function ClearCaseDocuments() {
    $('#docParentId').html(0);
    $('#ddlDocumentType').data('kendoComboBox').value("");
    $('#txtIssueDate').val("");
    $('#txtDocDescription').val("");
    $("#caseDocfiles").data("kendoUpload").destroy();
    $("#caseDocfiles").kendoUpload();
    $('#txtCaseSection').val("");
}

function DownloadDocuments(id) {
    DownloadCaseDocumentById(id)
}