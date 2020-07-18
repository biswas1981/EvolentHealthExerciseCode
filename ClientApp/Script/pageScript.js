var host="http://localhost:1238/";
var dataContactId="0";
$(function(){
	$("#msgAlert").hide();
	$("#btnEdit").prop('disabled', true);
});

$(document).ready(function () {
    $('#tblContact').DataTable({
        select: true,
        responsive: true,
        "ajax": {
            "url": host +"api/GetContacts",
            "dataSrc": "ResponseData"
        },
		
		"processing": true,
        "language": {
            "loadingRecords": '&nbsp;',
            "processing": 'Loading...'
        },  

        buttons: [
        {
            text: 'Reload',
            action: function (e, dt, node, config) {
                dt.ajax.reload();
            }
        }
        ],


        "columnDefs": [
           {
               "visible": true,
               orderable: false,
               "render": function (data, type, row, meta) {
                   var returnData = "<span data-id='" + data + "'>" + (meta.row + meta.settings._iDisplayStart + 1) + "</span>";
                   return returnData;
               },
               "targets": [0]
           },
           {
               "render": function (data, type, row) {
                   var returnData = "";
                   if (data == false) {
                       returnData = "Inactive";
                   }
                   else {
                       returnData = "Active";
                   }
                   return returnData;
               },
               "targets": 5
           }
        ],

        select: {
            style: 'os',
            selector: 'tr'
        },

        "columns": [
            
            { "data": "Id" },
            { "data": "FirstName" },
            { "data": "LastName" },
            { "data": "Email" },
            { "data": "PhoneNumber" },
            { "data": "Status" }
        ]
    });
});

function checkEmpty(txt)
{
	if( txt == '0' || txt == '' || txt == 'undefined' || txt == null )
	{
		return false;
	}
	else
	{
		return true;
	}
}

$(document).on('click', '#btnCreate', function () {
  $("#modalHeaderSpan").text("Add new contact");
})

$(document).on('click', '#btnSubmit', function () {
  var id=$("#contactId").val();
  var fname = $("#lblFirstName").val();
  var lname = $("#lblLastName").val();
  var email = $("#lblEmail").val();
  var phone = $("#lblPhone").val();
  var chkstatus = $("#chkStatus")[0].checked;
  var url="";
  var callType="";
  if(id=="0")
  {
	  url = "api/AddContact";
	  callType="POST";
  }
  else
  {
	  url = "api/EditContact";
	  callType="PUT";
  }
  
  if( checkEmpty(fname) && checkEmpty(lname) && checkEmpty(email))
  {
	var formData = {
	"Id":id,
	"FirstName":fname,
	"LastName": lname,
	"Email":email,
	"PhoneNumber":phone,
	"Status":chkstatus};
	$.ajax({
    url : host+url,
    type: callType,
    data : formData,
    success: function(data, textStatus, jqXHR)
    {
        if(data.ResponseData==true)
		{
			$("#msgAlert").removeClass("alert-success").removeClass("alert-danger");
				$("#msgAlert").html("Record added successfully.");
			$("#msgAlert").addClass("alert-success");
			alertHideShow();
		}
		else
		{
			$("#msgAlert").removeClass("alert-success").removeClass("alert-danger");
				$("#msgAlert").html("Error!");
			$("#msgAlert").addClass("alert-danger");
			alertHideShow();
		}
    },
    error: function (jqXHR, textStatus, errorThrown)
    {
		$("#msgAlert").removeClass("alert-success").removeClass("alert-danger");
			$("#msgAlert").html("Error!");
	    $("#msgAlert").addClass("alert-danger");
		alertHideShow();
    }
	});
  }
  
})

$(document).on('click', '.modalClose', function () {
	DataReload();
	ClearForm();
});

function DataReload()
{
	var table = $('#tblContact').DataTable();
	 table.ajax.reload();
}

$(document).on("click","#tblContact tbody tr", function(){
	if($(this).hasClass("selected")){
		dataContactId =  $(this).find("td").find("span")[0].dataset.id;
		$("#btnEdit").prop('disabled', false);
	}
	else{
		ClearForm();
	}
});


function ClearForm()
{
	$("#contactId").val("0");
	$("#myModal .modal-body form input[type=text]").val("");
	$("#myModal .modal-body form input[type=email]").val("");
	$("#myModal .modal-body form input[type=tel]").val("");
	$("#myModal .modal-body form input[type=checkbox]").prop('checked', false);
	$("#btnEdit").prop('disabled', true);
	dataContactId="0";
}


$(document).on("click","#btnEdit",function(){
	
	var selectedRowCell = $("#tblContact tbody tr.selected").find("td");
		if(selectedRowCell.length>0){
		$("#modalHeaderSpan").text("Edit contact");	
		$("#contactId").val($(selectedRowCell).eq(0).find("span")[0].dataset.id);
		$("#lblFirstName").val($(selectedRowCell)[1].textContent);
		$("#lblLastName").val($(selectedRowCell)[2].textContent);
		$("#lblEmail").val($(selectedRowCell)[3].textContent);
		$("#lblPhone").val($(selectedRowCell)[4].textContent);
		var statusText = $(selectedRowCell)[5].textContent;
		$("#chkStatus").prop('checked', statusText=="Active"?true:false);
	}
	else{
		return false;
	}
});

$(document).on("click","#btnDelete",function(){
	
	if(dataContactId!="0")
	{
	var isDelete = confirm('Are You Sure ?');
	if(isDelete==true)
	{
		$.ajax({
		url : host+"api/DeleteContact/"+dataContactId,
		type: "DELETE",
    success: function(data, textStatus, jqXHR)
    {
        if(data.ResponseData==true)
		{
			$("#msgAlert").removeClass("alert-success").removeClass("alert-danger");
				$("#msgAlert").html("Record deleted successfully.");
			$("#msgAlert").addClass("alert-success");
			DataReload();
		}
		else
		{
			$("#msgAlert").removeClass("alert-success").removeClass("alert-danger");
				$("#msgAlert").html("Error!");
			$("#msgAlert").addClass("alert-danger");			
		}
    },
    error: function (jqXHR, textStatus, errorThrown)
    {
		$("#msgAlert").removeClass("alert-success").removeClass("alert-danger");
			$("#msgAlert").html("Error!");
	    $("#msgAlert").addClass("alert-danger");		
    }
	});
	}
	}
});

function alertHideShow()
{
	$("#msgAlert").show();
	setTimeout(function(){ $("#msgAlert").hide(); }, 3000);
}