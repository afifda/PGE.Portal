$(document).ready(function () {        
    Init();
    $('#btnAddMasterBottomPic').click(function () {
        clearModalMasterBottomPic();
        $('#hfEditMode').val('0');
        $('#modalMasterBottomPic').modal('show');                
    });

    $('#btnSaveMasterBottomPic').click(function () {        
        var picPath = $('#fuAttachment').val()
        var validationMessage = "";

        if (picPath.length < 1) {
            validationMessage += "Picture harus di pilih. \n";
        }
        
        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveBottomPic();
    });

    $('#btnDelBottomPic').click(function () {
        var row = $('#hfdelrow').val();
    }); 
    
    $('#tblMasterBottomPic').on("click", ".btnDelete", deleteBottomPic);
   
});

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
    var $element = this;
    var row = $($element).parents("tr:first");      
    
    var masterMenu = new Object();
    masterMenu.Id = row.children()[0].innerText.trim();
    masterMenu.FileName = row.children()[1].innerText;    

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
    var EditMethod = true;
    var editMode = $("#hfEditMode").val();
    if (editMode == 0) EditMethod = false;       
    var masterMenu = new Object();

    masterMenu.Path = $("#fuAttachment").val();
    //var fname = masterMenu.Path.replace(/\\/g, '/');
    //masterMenu.FileName = fname.substring(fname.lastIndexOf('/') + 1, fname.lastIndexOf('.'));
    var lastIndex = masterMenu.Path.lastIndexOf("\\");
    if (lastIndex >= 0) {
        masterMenu.FileName = masterMenu.Path.substring(lastIndex + 1);
    }    

    var parameter = new Object();
    parameter.fileToUpload = JSON.stringify(masterMenu);
    parameter.isEdit = EditMethod;
        
        $.ajax({
            type: "POST",
            url: window.location.pathname + "/SaveMasterBottomPic",
            data: JSON.stringify(parameter),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: true,
            success: function (response) {
                var Menu = response.d;
                $("#modalMasterBottomPic").modal("hide");
                alert(Menu)
                Init();
            },
            error: function (response) {
                alert(response.responseText);
                $("#modalMasterBottomPic").modal("hide");
            }
        });   
}

