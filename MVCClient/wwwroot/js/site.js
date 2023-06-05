$(document).ready(function () {
   $("#btnUpdate").hide();
   //$("#MyModal").modal('hide');
   $("#btnSave").show();
   var IsEdit = false;
   $("#MyModal").modal({
      backdrop: 'static',
      keyboard: false,
      show: false
   });
   load()
   //$('#MyModal').modal({
   //        backdrop: 'static',
   //    keyboard: true,
   //    show: false
   //    });
   $("#btnModal").click(function () {
      $("#MyModal").modal('show')
      //$('#MyModal').modal({
      //    backdrop: 'static',
      //    keyboard: true,
      //    show: true
      //});

   })
   $("#btnSave").click(function () {
      var obj = {
         //id: $('#txtId').val(),
         //createdDate: $('#txtCreatedDate').val(),
         //modifiedDate: $('#txtModifiedDate').val(),
         //isActive: $('#check').val(),
         customerName: $("#txtCustomerName").val(),
         purchasesProduct: $("#txtPurchasesProduct").val(),
         paymentType: $("#txtPaymentType").val()

      }
      console.log(obj)
      $.ajax({

         url: "https://localhost:44395/api/CustomerInfos/InsertCustomer",
         type: "JSON",
         method: "POST",
         data: JSON.stringify(obj),
         contentType: "application/json",
         success: function (result) {
            $("#MyModal").modal('hide')
            clearALl();
            load();
         },
         error: function (er) {
            console.log(er)
         }
      })
   })
   //$("#btnUpdate").click(function () {

   //}

})
function clearALl() {
   $("#txtCustomerName").val(''),
      $("#txtPurchasesProduct").val(''),
      $("#txtPaymentType").val(''),
      $('#txtCreatedDate').val(''),
      $('#txtModifiedDate').val(''),
      $('#check').val(''),
      $("#txtId").empty()
}
function Close() {
   //alert(IsEdit);
   //if (IsEdit == false) {
   $("#MyModal").modal('hide');

   clearALl();
   // }
}
function load() {
   $.ajax({
      url: "https://localhost:44395/api/CustomerInfos/GetAllCustomer",
      type: "JSON",
      method: "GET",
      success: function (result) {
         //console.log(result)
         $("#tble tbody").empty();
         $.each(result, function (i, v) {
            //console.log(v)
            var html = "<tr><td>" + v.customerName + "</td>" +
               "<td>" + v.purchasesProduct + "</td>" +
               " <td>" + v.paymentType + "</td>" +
                 " <td> <button onClick='Edit(" + v.id + ")'><i class='fa-solid fa-pen-to-square'></i> </button></td>" +
                 " <td> <button onClick='Delete(" + v.id + ")'><i class='fa-solid fa-trash'></i> </button></td></tr>";

            $("#tble tbody").append(html)
         })
      },
      error: function (er) {
         console.log(er)
      }
   })
}
function Edit(id) {
   /*alert(id)*/
   $("#btnUpdate").show();
   $("#btnSave").hide();

   $.ajax({
      url: "https://localhost:44395/api/CustomerInfos/GetCustomer?id=" + id,
      type: "JSON",
      method: "GET",
      success: function (result) {
         $("#exampleModalLabel").html("Update Customer Information");
         console.log(result)
         IsEdit = true;
         $("#txtId").val(result.id),
            $("#txtCustomerName").val(result.customerName),
            $("#txtPurchasesProduct").val(result.purchasesProduct),
            $("#txtPaymentType").val(result.paymentType),
            $("#MyModal").modal('show')
      },
      error: function (er) {
         console.log(er)
      }
   })

}
function Update() {
   var Id = $('#txtId').val();
   /*alert(Id);*/
   var url = "https://localhost:44395/api/CustomerInfos/UpdateCustomer?id=" + Id;
   var updateInfo = {
      Id: $('#txtId').val(),
      CustomerName: $("#txtCustomerName").val(),
      PurchasesProduct: $("#txtPurchasesProduct").val(),
      PaymentType: $("#txtPaymentType").val()
    }
    console.log(updateInfo);
    $("#MyModal").modal('hide');
    $.ajax({
      url: url,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      type: "Put",
      data: JSON.stringify(updateInfo),
       success: function (result) {
         $("#MyModal").modal({
            //backdrop: 'static',
            //keyboard: false,
            show: false
         });
         load();
         clearALl();
         //console.log("....")
         //console.log(result)
         //if (result > 0 ) {
         //    load();
         //    clearALl();

         //}
         $("#btnUpdate").hide();
         $("#btnSave").show();
      },
      error: function (er) {
         console.log(er.responseText);
      }
   })
}
function Delete(id) {
   /*alert(id);*/
   var url = "https://localhost:44395/api/CustomerInfos/DeleteCustomer?id=" + id;
   $.ajax({
      url: url,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      type: "Delete",
      success: function (result) {
         load()
      },
      error: function (msg) {
         alert(msg);
      }
   });
}