$(document).ready(function () {

    LoadMainKategory();

    Init();

    $('#btnAddMasterKategoryAppChild').click(function () {
        clearModalMasterKategoryAppChild();
        $('#hfEditMode').val('0');
        $('#modalMasterKategoryAppChild').modal('show');
    });

    $('#btnSaveMasterKategoryAppChild').click(function () {
        var childName = $("#txtKategoryAppChildName").val();
        var childUrl = $("#txtUrl").val();
        var validationMessage = "";
        if (childName.length < 1) {
            validationMessage += "Nama Kategori Child harus di isi. \n";
        }
        if (childUrl.length < 1) {
            validationMessage += "Url Kategori Child harus di isi. \n";
        }

        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        saveKategoryAppChild();
    });

    $('#tblMasterKategoryAppChild').on("click", ".btnEdit", editKategoryAppChild);

    $('#tblMasterKategoryAppChild').on("click", ".btnDelete", deleteKategoryAppChild);

});

function clearModalMasterKategoryAppChild() {
    $("#txtKategoryAppChildName").val("");
    $("#txtUrl").val("");
}

function Init() {
    $('#tblMasterKategoryAppChild tbody').remove();
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterMainKategoryAppChild",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var KategoryAppChild = response.d;
            if (KategoryAppChild.length > 0) {
                for (i = 0; i < KategoryAppChild.length; i++) {
                    var seq = i + 1;
                    var strhtml = '<tr id="MenuRow_"' + seq + '>' +
                    '<td style = "display:none">' + KategoryAppChild[i].Id + ' </td>' +
					'<td style = "display:none">' + KategoryAppChild[i].ParentId + ' </td>' +
                    '<td >' + KategoryAppChild[i].LinkAppKategoryName + ' </td>' +
                    '<td >' + KategoryAppChild[i].LinkAppName + ' </td>' +
                    '<td >' + KategoryAppChild[i].LinkAppUrl + ' </td>' +
                    '<td align="Center"><input type="button"  class="button2 btnEdit" value="Ubah"/><input type="button"  class="button2 btnDelete" value="Hapus"/> </td> ' +
                    '</tr>';
                    $(strhtml).appendTo($("#tblMasterKategoryAppChild"));
                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function LoadMainKategory() {
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMainKategory",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var MainKategory = response.d;
            if (MainKategory.length > 0)
                for (i = 0; i < MainKategory.length; i++) {
                    var seq = i + 1;
                    $("#ddlParentName").append($("<option></option>").val
                   (MainKategory[i].Id).html(MainKategory[i].LinkAppKategoryName));
                };
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function editKategoryAppChild() {
    var $element = this;
    var row = $($element).parents("tr:first");

    clearModalMasterKategoryAppChild();
    $("#hfEditMode").val("1");
    $("#modalMasterKategoryAppChild").modal("show");
    $("#hfId").val(row.children()[0].innerText.trim());
    $("#ddlParentName").val(row.children()[1].innerText.trim());
    $("#txtKategoryAppChildName").val(row.children()[3].innerText);
    $("#txtUrl").val(row.children()[4].innerText);
}

function deleteKategoryAppChild() {
    var $element = this;
    var row = $($element).parents("tr:first");
    $("#dialog-confirm").html("Apakah anda yakin menghapus Kategory Child ini?");

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
                    url: window.location.pathname + "/DeleteMasterKategoryAppChild",
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
                        $("#modalMasterKategoryAppChild").modal("hide");
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

function saveKategoryAppChild() {
    var EditMethod = true;
    var editMode = $("#hfEditMode").val();
    var MasterKategoryAppChild = new Object();
    if (editMode == 0)
    { EditMethod = false; } else { MasterKategoryAppChild.Id = $("#hfId").val(); }
    MasterKategoryAppChild.ParentId = $('#ddlParentName').val();
    MasterKategoryAppChild.LinkAppName = $("#txtKategoryAppChildName").val();
    MasterKategoryAppChild.LinkAppUrl = $("#txtUrl").val();
    var parameter = new Object();
    parameter.masterKategoryAppChildString = JSON.stringify(MasterKategoryAppChild);
    parameter.isEdit = EditMethod;

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/SaveMasterKategoryAppChild",
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Menu = response.d;
            $("#modalMasterKategoryAppChild").modal("hide");
            alert(Menu)
            Init();
        },
        error: function (response) {
            alert(response.responseText);
            $("#modalMasterKategoryAppChild").modal("hide");
        }
    });
}

