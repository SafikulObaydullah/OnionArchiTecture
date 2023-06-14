var BuyerList = []

$(document).ready(function () {
   $("#cmbBuyer").kendoComboBox({
      placeholder: 'Select Buyer',
      dataTextField: 'Buyer',
      dataValueField: 'id',
      dataSource: []
   });
   NotifyConsigneeLoad();
});
function NotifyConsigneeLoad() {
   $.ajax({
      url: "Configuration/SaveNotifyConsignee",
      method: "GET",
      dataType: "json",
      success: function (data) {
         console.log(data);
         BuyerList = data.buyer;
         NotiConsigneeDataBind();
         $("#cmbBuyer").data('kendoComboBox').dataSource.data(BuyerList);
      }
   });
}
function NotiConsigneeDataBind() {
   $("#gridNotify").kendoGrid({
      dataSource: BuyerList,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["buyer", "Name"]
      },
      pageable: {
         pageSize: 15,
         pageSizes: [15, 30, 50, "all"],
         numeric: false
      },
      columns: [
         {
            title: "ID",
            field: "id", width: 50,
         },
         {
            title: "Buyer",
            field: "buyer", width: 90
         },
         {
            title: "Name",
            field: "name", width: 90
         },
         {
            title: "type",
            field: "type", width: 60
         },
         {
            title: "Address",
            field: "address", width: 90
         },
         {
            title: "Description",
            field: "description",
         },
         {
            title: "Action",
            template: "<button class='btn btn-success' title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
            field:"",width:80
         },
      ]
   });
}
function SaveNotifyConsignee() {
   var obj = new Object();
   var validate = true;
   validate = Validate();
   if (validate == true) {
      obj.id = $('#spanParentID').html();
      obj.buyer = $('#cmbBuyer').data("kendoComboBox").value();
      obj.name = $('#txtName').val();
      obj.type = $('#isType').is(':checked') ? true : false;
      obj.address = $('#txtAddress').val();
      obj.description = $('#txtDescription').val();
      $.ajax({
         url: "/Configuration/SaveNotifyConsignee",
         type: "POST",
         data: obj,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               NotifyConsigneeLoad();
            } else {
               toastr.warning(data.message, "Waring");
            }
         },
         error: function (xhr, textStatus, errorThrown) {
            toastr.warning("Error Saving", "Waring");
         }
      });
   }
}
function Edit(id) {
   $('#spanParentID').html(id);
   var FilterData = _.filter(BuyerList, function (item) { item.id == id });
   FilterData[0].parentid == 0 ? "" : $("#cmbBuyer").data("kendoComboBox").value(FilterData[0].parentid);
   FilterData[0].isActive == false ? $("#isType").prop('checked', false) : $("#isType").prop('checked',true);
   $('#name').val(FilterData[0].name);
   $('#txtAddress').val(FilterData[0].address);
   $('#txtDescription').val(FilterData[0].description);
}
function Validate() {
   if ($('#cmbBuyer').data("KendoComboBox").value() == "" || $('#cmbBuyer').data("KendoComboBox").selectedIndex == -1) {
      $('#cmbBuyer').focus();
      popupNotification.warning('Please input Buyer Name');
      return false;
   }
   if ($('#txtName').val() == "") {
      $('#name').focus();
      popupNotification.warning('Please input name');
      return false;
   }
   if ($('#isType').is(':checked') ? true : false) {
      $('#isType').fucus();
      popupNotification.warning('Please check type');
      return false;
   }
   if ($('#txtAddress').val() == "") {
      $('#txtAddress').focus();
      popupNotification.warning('Please input Address');
      return false;
   }
   if ($('#txtDescription').val() == "") {
      $('#txtDescription').focus();
      popupNotification.warning('Please input Description');
      return false;
   }
   return true;
}