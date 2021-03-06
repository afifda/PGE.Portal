﻿$(document).ready(function () {        
    Init();
    $('#btnAddMasterBottomPic').click(function () {
        clearModalMasterBottomPic();
        $('#hfEditMode').val('0');
        $('#modalMasterBottomPic').modal('show');                
    });

    $('#btnSaveMasterBottomPic').click(function () {        
        var picPath = $('#fuAttachment').val()
        var linkTo  = $("#txtLinkTo").val();
        var validationMessage = "";

        if (picPath.length < 1) {
            validationMessage += "Picture harus di pilih. \n";
        }
        if (linkTo.length < 1) {
            validationMessage += "Link To harus di isi. \n";
        }
        
        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveBottomPic();
    });

    $('#btnDelBottomPic').click(function () {
        deleteBottomPic();

    }); 
    
    $('#tblMasterBottomPic').on("click", ".btnDelete", showDeleteDialog);
   
});

function showDeleteDialog() {
    var $element = this;
    var row = $($element).parents("tr:first");
    $("#hfdelrow").val(row.children()[0].innerText)
    $("#hffilename").val(row.children()[1].innerText)
    $('#modalMasterBottomPicDelete').modal('show');
}

function clearModalMasterBottomPic() {        
    var _fileuploadcontrolId = $("#fuAttachment");
    _fileuploadcontrolId.replaceWith(_fileuploadcontrolId = _fileuploadcontrolId.clone(true));
}

function Init() {
    $('#tblMasterBottomPic tbody').remove();
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterBottomPic",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var picList = response.d;
            if (picList.length > 0) {
                for (i = 0; i < picList.length; i++) {
                    var seq = i + 1;
                    var strhtml = '<tr id="MenuRow_"' + seq + '>' +
                    '<td style = "display:none">' + picList[i].Id + ' </td>' +
                    '<td >' + picList[i].FileName + ' </td>' +
                    '<td >' + picList[i].Path + ' </td>' +
                    '<td >' + picList[i].LinkTo + ' </td>' +
                    '<td align="Center"><input type="button"  class="button2 btnDelete" value="Hapus"/> </td> ' +
                    '</tr>';
                    $(strhtml).appendTo($("#tblMasterBottomPic"));
                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function editMenu() {
    var $element = this;
    var row = $($element).parents("tr:first");

    clearModalMasterMenu();
    $("#hfEditMode").val("1");
    $("#modalMasterMenu").modal("show");
    $("#txtNamaMenu").attr('disabled', true);
    $("#txtNamaMenu").val(row.children()[1].innerText)
    $("#txtUrl").val(row.children()[2].innerText)
}

function deleteBottomPic() {        
    var masterMenu = new Object();
    masterMenu.Id = $("#hfdelrow").val().trim();
    masterMenu.FileName = $("#hffilename").val().trim();

    var parameter = new Object();
    parameter.fileToUpload = JSON.stringify(masterMenu);

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/DeleteMasterBottomPic",
        async: false,
        cache: false,
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var Menu = response.d;
            if (Menu == "Success") {
                $('#modalMasterBottomPicDelete').modal('hide');
                alert("Master Bottom Picture telah dihapus.")
                Init();
            }
        },
        error: function (response) {
            alert(response.responseText);            
        }
    });    
}

function saveBottomPic() {
    //var EditMethod = true;
    //var editMode = $("#hfEditMode").val();
    //if (editMode == 0) EditMethod = false;       
    //var masterMenu = new Object();

    //masterMenu.Path = $("#fuAttachment").val();
    //masterMenu.LinkTo = $("#txtLinkTo").val();   
    //var lastIndex = masterMenu.Path.lastIndexOf("\\");
    //if (lastIndex >= 0) {
    //    masterMenu.FileName = masterMenu.Path.substring(lastIndex + 1);
    //}

    //save image to TempFile
    
    var DocLink = $("#fuAttachment").get(0);
    var DocFile = DocLink.files;
    var LinkTo = $("#txtLinkTo").val();
    var handlerurl = "/_layouts/15/GenericPortal.ashx?Method=uploadImage&link=" + LinkTo;
    var files = document.getElementById('fuAttachment').files;

    var data = new FormData();
    for (var  i=0;i<DocFile.length;i++)
    {
        data.append(DocFile[i].name, DocFile[i]);
    }

    $.ajax({
        type: "POST",
        url: handlerurl,
        data: data,
        contentType:false,
        processData:false,
        datatype: "json",
        success: function (response) {
                        var Menu = response;
                        $("#modalMasterBottomPic").modal("hide");
                        alert(Menu)
                        Init();
                    },
                    error: function (response) {
                        alert(response.responseText);
                        $("#modalMasterBottomPic").modal("hide");
                    }
    });
    //end    
}

