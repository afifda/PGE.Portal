$(document).ready(function () {
    Init();
    var dateFormat = "dd-MMM-yyyy";
    var DATE_FORMAT_ENTRY = "dd-M-yy";
    $('#txtDataEvent').datepicker({ dateFormat: DATE_FORMAT_ENTRY });
    //$('#txtDataEvent').datepicker();
    $('#btnAddMasterEvent').click(function () {
        clearModalMasterMainPic();
        $('#hfEditMode').val('0');
        $('#modalMasterEvent').modal('show');
    });

    $('#btnSaveMasterEvent').click(function () {
        $('#modalMasterEvent').modal('hide');
        $body = $("body");
        $body.addClass("loading");
        var validationMessage = "";
        var Title = $("#txtTitle").val();
        var DateEvent = $("#txtDataEvent").val();
        var Desc = $("#txtDesc").val();
        var picPath = $('#fuAttachment').val();

        if (Title.length < 1) {
            validationMessage += "Title harus di isi. \n";
        }
        if (DateEvent.length < 1) {
            validationMessage += "Tanggal Event harus di isi. \n";
        }
        if (Desc.length < 1) {
            validationMessage += "Description Event harus di isi. \n";
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

    $('#modalMasterMainEventDelete').click(function () {
        var row = $('#hfdelrow').val();
    });

    $('#tblMasterMainPic').on("click", ".btnDelete", deleteMainPic);

});

function clearModalMasterMainPic() {
    var _fileuploadcontrolId = $("#fuAttachment");
    _fileuploadcontrolId.replaceWith(_fileuploadcontrolId = _fileuploadcontrolId.clone(true));
    $("#txtTitle").val("");
    $("#txtDataEvent").val("");
    $("#txtDesc").val("");
}

function Init() {
    $('#tblMasterMainPic tbody').remove();
    var dateFormat = "dd-MMM-yyyy";
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterEvent",
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
                    '<td >' + picList[i].Tittle + ' </td>' +
                    '<td >' + formatDate(dateFromJSON(picList[i].DateEvent), dateFormat) + ' </td>' +
                    '<td >' + picList[i].EventText + ' </td>' +
                    '<td >' + picList[i].PicturePath + ' </td>' +
                    '<td >' + picList[i].FileName + ' </td>' +
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
    $("#modalMasterEvent").modal("show");
    $("#txtTitle").attr('disabled', true);
    $("#txtTitle").val(row.children()[1].innerText)
    $("#txtDataEvent").val(row.children()[2].innerText)
    $("#txtDesc").val(row.children()[3].innerText)
    $("#file").val(row.children()[4].innerText)
}

function deleteMainPic() {
    $("#modalMasterEvent").modal("hide");
    $body = $("body");
    $body.addClass("loading");
    var $element = this;
    var row = $($element).parents("tr:first");

    var masterEvent = new Object();
    masterEvent.Id = row.children()[0].innerText.trim();
    masterEvent.Tittle = row.children()[1].innerText;
    masterEvent.DataEvent = row.children()[2].innerText;
    masterEvent.EventText = row.children()[3].innerText;
    masterEvent.PicturePath = row.children()[4].innerText;
    masterEvent.FileName = row.children()[5].innerText;


    var lastIndex = masterEvent.PicturePath.lastIndexOf("\\");
    if (lastIndex >= 0) {
        masterEvent.FileName = masterEvent.PicturePath.substring(lastIndex + 1);
    }

    var parameter = new Object();
    parameter.fileToUpload = JSON.stringify(masterEvent);

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/DeleteMasterEvent",
        async: false,
        cache: false,
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var Menu = response.d;
            if (Menu == "Success") {
                $body.removeClass("loading");                
                alert("Master Event telah dihapus.")
                Init();
            }
        },
        error: function (response) {            
            $body.removeClass("loading");
            alert(response.responseText);
        }
    });
}

function saveMainPic() {
    //var EditMethod = true;
    //var editMode = $("#hfEditMode").val();
    //if (editMode == 0) EditMethod = false;
    //var masterEvent = new Object();
    //masterEvent.PicturePath = $("#fuAttachment").val();
    //masterEvent.Tittle = $("#txtTitle").val();
    //masterEvent.DateEvent = $("#txtDataEvent").val();
    //masterEvent.EventText = $("#txtDesc").val();

    //var lastIndex = masterEvent.PicturePath.lastIndexOf("\\");
    //if (lastIndex >= 0) {
    //    masterEvent.FileName = masterEvent.PicturePath.substring(lastIndex + 1);
    //}

    //var parameter = new Object();
    //parameter.fileToUpload = JSON.stringify(masterEvent);
    //parameter.isEdit = EditMethod;

    //$.ajax({
    //    type: "POST",
    //    url: window.location.pathname + "/SaveMasterEvent",
    //    data: JSON.stringify(parameter),
    //    contentType: "application/json; charset=utf-8",
    //    datatype: "json",
    //    async: true,
    //    success: function (response) {
    //        var Menu = response.d;
    //        $("#modalMasterEvent").modal("hide");
    //        $body.removeClass("loading");
    //        alert(Menu)
    //        Init();
    //    },
    //    error: function (response) {
    //        alert(response.responseText);s
    //        $body.removeClass("loading");
    //        $("#modalMasterEvent").modal("hide");
    //    }
    //});

    var DocLink = $("#fuAttachment").get(0);
    var DocFile = DocLink.files;
    var files = document.getElementById('fuAttachment').files;

    var Tittle = $("#txtTitle").val();
    var DateEvent = $("#txtDataEvent").val();
    var EventText = $("#txtDesc").val();

    var handlerurl = "/_layouts/15/GenericPortal.ashx?Method=uploadimageevent&tittle=" + Tittle + "&dateevent=" + DateEvent + "&text=" + EventText;

    var data = new FormData();
    for (var i = 0; i < DocFile.length; i++) {
        data.append(DocFile[i].name, DocFile[i]);
    }

    $.ajax({
        type: "POST",
        url: handlerurl,
        data: data,
        contentType: false,
        processData: false,
        datatype: "json",
        success: function (response) {
            var Menu = response;
            $("#modalMasterEvent").modal("hide");
            $body.removeClass("loading");
            alert(Menu)
            Init();
        },
        error: function (response) {
            $body.removeClass("loading");
            alert(response.responseText);
            $("#modalMasterEvent").modal("hide");
        }
    });
}

