$(document).ready(function () {

    LoadMainMenu();

    Init();

    $('#btnAddMasterMenuChild').click(function () {
        clearModalMasterMenuChild();
        $('#hfEditMode').val('0');
        $('#modalMasterMenuChild').modal('show');
    });

    $('#btnSaveMasterMenuChild').click(function () {
        var childName = $("#txtMenuChildName").val();
        var childUrl = $("#txtUrl").val();
        var validationMessage = "";
        if (childName.length < 1) {
            validationMessage += "Nama Menu Child harus di isi. \n";
        }
        if (childUrl.length < 1) {
            validationMessage += "Url Menu Child harus di isi. \n";
        }

        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveMenuChild();
    });

    $('#tblMasterMenuChild').on("click", ".btnEdit", editMenuChild);

    $('#tblMasterMenuChild').on("click", ".btnDelete", deleteMenuChild);

});

function clearModalMasterMenuChild() {
    $("#txtMenuChildName").val("");
    $("#txtUrl").val("");
}

function Init() {
    $('#tblMasterMenuChild tbody').remove();
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterMainMenuChild",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var MenuChild = response.d;
            if (MenuChild.length > 0) {
                for (i = 0; i < MenuChild.length; i++) {
                    var seq = i + 1;
                    var strhtml = '<tr id="MenuRow_"' + seq + '>' +
                    '<td style = "display:none">' + MenuChild[i].Id + ' </td>' +
					'<td style = "display:none">' + MenuChild[i].ParentId + ' </td>' +
                    '<td >' + MenuChild[i].MenuName + ' </td>' +
                    '<td >' + MenuChild[i].MenuChildName + ' </td>' +
                    '<td >' + MenuChild[i].MenuChildUrl + ' </td>' +
                    '<td align="Center"><input type="button"  class="button2 btnEdit" value="Ubah"/><input type="button"  class="button2 btnDelete" value="Hapus"/> </td> ' +
                    '</tr>';
                    $(strhtml).appendTo($("#tblMasterMenuChild"));
                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function LoadMainMenu() {
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMainMenu",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var mainMenu = response.d;
            if (mainMenu.length > 0)
                for (i = 0; i < mainMenu.length; i++) {
                    var seq = i + 1;
                    $("#ddlParentName").append($("<option></option>").val
                   (mainMenu[i].Id).html(mainMenu[i].MenuName));
                };
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function editMenuChild() {
    var $element = this;
    var row = $($element).parents("tr:first");

    clearModalMasterMenuChild();
    $("#hfEditMode").val("1");
    $("#modalMasterMenuChild").modal("show");
    $("#hfId").val(row.children()[0].innerText.trim());
    $("#ddlParentName").val(row.children()[1].innerText.trim());
    $("#txtMenuChildName").val(row.children()[3].innerText);
    $("#txtUrl").val(row.children()[4].innerText);
}

function deleteMenuChild() {
    var $element = this;
    var row = $($element).parents("tr:first");
    $("#dialog-confirm").html("Apakah anda yakin menghapus Menu Child ini?");

    // Define the Dialog and its properties.
    $("#dialog-confirm").dialog({
        resizable: false,
        modal: true,
        title: "Warning",
        height: 150,
        width: 350,
        buttons: {
            "Ya": function () {

                var menuNameChildKey = row.children()[0].innerText;
                var parameter = {
                    IdChild: menuNameChildKey
                };
                $.ajax({
                    type: "POST",
                    url: window.location.pathname + "/DeleteMasterMenuChild",
                    async: false,
                    cache: false,
                    data: JSON.stringify(parameter),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: false,
                    success: function (response) {
                        var Menu = response.d;
                        if (Menu == "Success") {
                            alert("Master Menu telah dihapus.")
                            Init();
                        }
                    },
                    error: function (response) {
                        alert(response.responseText);
                        $("#modalMasterMenuChild").modal("hide");
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

function saveMenuChild() {
    var EditMethod = true;
    var editMode = $("#hfEditMode").val();
    var MasterMenuChild = new Object();
    if (editMode == 0)
    { EditMethod = false; } else { MasterMenuChild.Id = $("#hfId").val(); }
    MasterMenuChild.ParentId = $('#ddlParentName').val();
    MasterMenuChild.MenuChildName = $("#txtMenuChildName").val();
    MasterMenuChild.MenuChildUrl = $("#txtUrl").val();
    var parameter = new Object();
    parameter.masterMenuChildString = JSON.stringify(MasterMenuChild);
    parameter.isEdit = EditMethod;

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/SaveMasterMenuChild",
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Menu = response.d;
            $("#modalMasterMenuChild").modal("hide");
            alert(Menu)
            Init();
        },
        error: function (response) {
            alert(response.responseText);
            $("#modalMasterMenuChild").modal("hide");
        }
    });
}

