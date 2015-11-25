$(document).ready(function () {        

    $('#btnAddMasterMainPic').click(function () {
        clearModalMasterMenu();
        $('#hfEditMode').val('0');
        $('#modalMasterMainPic').modal('show');                
    });

    $('#btnSaveMasterMainPic').click(function () {
        var picName = $("#txtPicName").val();
        var picPath = $('#fuAttachment').val()
        var validationMessage = "";
        if (picName.length < 1) {
            validationMessage += "Picture Name harus di isi. \n";
        }

        if (picPath.length < 1) {
            validationMessage += "Picture harus di pilih. \n";
        }
        
        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveMainPic();
    });

    $('#tblMasterMainPic').on("click", ".btnEdit", editMenu);
    $('#tblMasterMainPic').on("click", ".btnDelete", deleteMenu);

    $('#fuAttachment').change(function (event) {
        //var filename = document.getElementById("fuAttachment").value
        //var ext = filename.substr(filename.lastIndexOf('.') + 1);
        //alert(filename);
        //alert(ext);

        //var fpath = this.value;

        //fpath = fpath.replace(/\\/g, '/');

        //var fname = fpath.substring(fpath.lastIndexOf('/') + 1, fpath.lastIndexOf('.'));

        //alert(fname);

        //mainMenu    

        var input = document.getElementById("fuAttachment");
        var fReader = new FileReader();
        fReader.readAsDataURL(input.files[0]);
        fReader.onloadend = function (event) {
            var img = document.getElementById("fuAttachment");
            img.src = event.target.result;
            alert(img.src);

        }
        //var filename = $(this).val();
        //var lastIndex = filename.lastIndexOf("\\");
        //if (lastIndex >= 0) {
        //    filename = filename.substring(lastIndex + 1);
        //}
        //$('#fuAttachment').val(filename);


    });
});

function clearModalMasterMenu() {
    $("#txtPicName").val("");
    $("input[id$='fuAttachment']").val("");    
}

function Init() {
    $('#tblMasterMainPic tbody').remove();
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterMainMenu",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Menu = response.d;
            if (Menu.length > 0) {
                for (i = 0; i < Menu.length; i++) {
                    var seq = i + 1;
                    var strhtml = '<tr id="MenuRow_"' + seq + '>' +
                    '<td style = "display:none">' + Menu[i].MenuName + ' </td>' +
                    '<td >' + Menu[i].MenuName + ' </td>' +
                    '<td >' + Menu[i].MenuUrl + ' </td>' +
                    '<td align="Center"><input type="button"  class="button2 btnEdit" value="Ubah"/><input type="button"  class="button2 btnDelete" value="Hapus"/> </td> ' +
                    '</tr>';
                    $(strhtml).appendTo($("#tblMasterMenu"));
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

function deleteMenu() {
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

