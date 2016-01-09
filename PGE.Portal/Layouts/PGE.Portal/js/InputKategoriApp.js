$(document).ready(function () {
    Init();

    $('#btnAddKategoriApp').click(function () {
        clearModalMasterkategoriApp();
        $('#hfEditMode').val('0');
        $('#modalMasterKategoriApp').modal('show');
    });

    $('#btnSaveKategoriApp').click(function () {
        var KategoryName = $("#txtNamaKategoriApp").val();
        var validationMessage = "";
        if (KategoryName.length < 1) {
            validationMessage += "Nama Kategory App harus di isi. \n";
        }
        if (validationMessage.length > 0) {
            alert(validationMessage);
            return false;
        }
        savekategoriApp();
    });

    $('#tblMasterKategoriApp').on("click", ".btnDelete", deletekategoriApp);

    $('#tblMasterKategoriApp').on("click", ".btnEdit", editMenuMainApp);
});

function clearModalMasterkategoriApp() {
    $("#txtNamaKategoriApp").val("");
}

function Init() {
    $('#tblMasterKategoriApp tbody').remove();
    $("#modalMasterKategoriApp").modal("hide");
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterKategoriApp",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var kategoriApp = response.d;
            if (kategoriApp.length > 0) {
                for (i = 0; i < kategoriApp.length; i++) {
                    var seq = i + 1;
                    var strhtml = '<tr id="MenuRow_"' + seq + '>' +
                    '<td style = "display:none">' + kategoriApp[i].Id + ' </td>' +
                    '<td >' + kategoriApp[i].LinkAppKategoryName + ' </td>' +
                    '<td align="Center"><input type="button"  class="button2 btnEdit" value="Ubah"/></td> ' +
                    '</tr>';
                    $(strhtml).appendTo($("#tblMasterKategoriApp"));
                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function deletekategoriApp() {
    var $element = this;
    var row = $($element).parents("tr:first");
    $("#dialog-confirm").html("Apakah anda yakin menghapus kategori ini?");

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
                    masterkategoryAppString: menuNameKey
                };
                $.ajax({
                    type: "POST",
                    url: window.location.pathname + "/DeleteKategoryApp",
                    async: false,
                    cache: false,
                    data: JSON.stringify(parameter),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: false,
                    success: function (response) {
                        var kategoriApp = response.d;
                        if (kategoriApp == "Success") {
                            alert("Master Kategori Aplikasi telah dihapus.")
                            Init();
                        }
                    },
                    error: function (response) {
                        alert(response.responseText);
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

function savekategoriApp() {
    var EditMethod = true;
    var editMode = $("#hfEditMode").val();
    var masterkategoriApp = new Object();

    if (editMode == 0)
    { EditMethod = false; } else { masterkategoriApp.Id = $("#hfId").val(); }    
    masterkategoriApp.LinkAppKategoryName = $("#txtNamaKategoriApp").val();    
    var parameter = new Object();
    parameter.LinkAppKategoryName = JSON.stringify(masterkategoriApp);
    parameter.isEdit = EditMethod;

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/SaveKategoryApp",
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var kategoriApp = response.d;
            alert(kategoriApp)
            Init();
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function editMenuMainApp() {
    var $element = this;
    var row = $($element).parents("tr:first");

    clearModalMasterkategoriApp();
    $("#hfEditMode").val("1");
    $("#modalMasterKategoriApp").modal("show");
    $("#hfId").val(row.children()[0].innerText.trim());
    $("#txtNamaKategoriApp").val(row.children()[1].innerText.trim());  
}

