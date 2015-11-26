$(document).ready(function () {        
    Init();
    $('#btnAddMasterMainPic').click(function () {
        clearModalMasterMainPic();
        $('#hfEditMode').val('0');
        $('#modalMasterMainPic').modal('show');                
    });

    $('#btnSaveMasterMainPic').click(function () {        
        var picPath = $('#fuAttachment').val()
        var validationMessage = "";

        if (picPath.length < 1) {
            validationMessage += "Picture harus di pilih. \n";
        }
        
        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveMainPic();
    });

    $('#btnDelMainPic').click(function () {
        var row = $('#hfdelrow').val();
    }); 
    
    $('#tblMasterMainPic').on("click", ".btnDelete", deleteMainPic);
   
});

function clearModalMasterMainPic() {        
    var _fileuploadcontrolId = $("#fuAttachment");
    _fileuploadcontrolId.replaceWith(_fileuploadcontrolId = _fileuploadcontrolId.clone(true));
}

function Init() {
    $('#tblMasterMainPic tbody').remove();
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterMainPic",
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
                    $(strhtml).appendTo($("#tblMasterMainPic"));
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

function deleteMainPic() {
    var $element = this;
    var row = $($element).parents("tr:first");      
    
    var masterMenu = new Object();
    masterMenu.Id = row.children()[0].innerText.trim();
    masterMenu.FileName = row.children()[1].innerText;    

    var parameter = new Object();
    parameter.fileToUpload = JSON.stringify(masterMenu);

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/DeleteMasterMainPic",
        async: false,
        cache: false,
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var Menu = response.d;
            if (Menu == "Success") {                
                alert("Master Main Picture telah dihapus.")
                Init();
            }
        },
        error: function (response) {
            alert(response.responseText);            
        }
    });    
}

function saveMainPic() {
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
            url: window.location.pathname + "/SaveMasterMainPic",
            data: JSON.stringify(parameter),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: true,
            success: function (response) {
                var Menu = response.d;
                $("#modalMasterMainPic").modal("hide");
                alert(Menu)
                Init();
            },
            error: function (response) {
                alert(response.responseText);
                $("#modalMasterMainPic").modal("hide");
            }
        });   
}

