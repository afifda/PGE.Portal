$(document).ready(function () {
    Init();

    $('#btnAddMasterMenu').click(function () {
        clearModalMasterMenu();
        $('#hfEditMode').val('0');
        $('#modalMasterMenu').modal('show');
        $("#txtNamaMenu").attr('disabled', false);
    });

    $('#btnSaveMasterMenu').click(function () {
        var Menu_Nama = $("#txtNamaMenu").val();
        var validationMessage = "";
        if (Menu_Nama.length < 1) {
            validationMessage += "Nama Menu harus di isi. \n";
        }
        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveMenu();
    });

    $('#tblMasterMenu').on("click", ".btnEdit", editMenu);
    $('#tblMasterMenu').on("click", ".btnDelete", deleteMenu);
});

function clearModalMasterMenu() {
    $("#txtNamaMenu").val("");
    $("#txtUrl").val("");
}

function Init() {
    $('#tblMasterMenu tbody').remove();
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

function saveMenu() {
    var EditMethod = true;
    var editMode = $("#hfEditMode").val();
    if (editMode == 0) EditMethod = false;
    var masterMenu = new Object();
    masterMenu.MenuName = $("#txtNamaMenu").val();
    masterMenu.MenuUrl = $("#txtUrl").val();
    var parameter = new Object();
    parameter.masterMenuString = JSON.stringify(masterMenu);
    parameter.isEdit = EditMethod;

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/SaveMasterMenu",
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Menu = response.d;
            $("#modalMasterMenu").modal("hide");
            alert(Menu)
            Init();
        },
        error: function (response) {
            alert(response.responseText);
            $("#modalMasterMenu").modal("hide");
        }
    });
}

