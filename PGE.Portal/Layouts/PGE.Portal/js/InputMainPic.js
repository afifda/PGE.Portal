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
    
    $('#tblMasterMainPic').on("click", ".btnDelete", deleteMainPic);
   
});

function clearModalMasterMainPic() {
    $("#fuAttachment").val("");    
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
    $("#dialog-confirm").html("Apakah anda yakin menghapus Menu ini?");

    // Define the Dialog and its properties.
    $("#dialog-confirm").dialog({
        resizable: false,
        modal: true,
        title: "Warning",
        height: 150,
        width: 350,
        buttons: {
            "Ya": function () {

                var menuNameKey = row.children()[1].innerText;
                var parameter = {
                    menuName: menuNameKey
                };
                $.ajax({
                    type: "POST",
                    url: window.location.pathname + "/DeleteMasterMenu",
                    async: false,
                    cache: false,
                    data: JSON.stringify(parameter),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: false,
                    success: function (response) {
                        var Menu = response.d;
                        if (Menu == "Success") {
                            $("#modalMasterMenu").modal("hide");
                            alert("Master Menu telah dihapus.")
                            Init();
                        }
                    },
                    error: function (response) {
                        alert(response.responseText);
                        $("#modalMasterMenu").modal("hide");
                    }
                });
                $(this).dialog('close');
            },
            "Tidak": function () {
                $(this).dialog('close');
            }
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

