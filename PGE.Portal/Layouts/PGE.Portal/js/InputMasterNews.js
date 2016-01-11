$(document).ready(function () {
    Init();
    var dateFormat = "dd-MMM-yyyy";
    var DATE_FORMAT_ENTRY = "dd-M-yy";
    $('#txtDateNews').datepicker();
    //$('#txtDataEvent').datepicker({ dateFormat: DATE_FORMAT_ENTRY });
    $('#btnAddMasterNews').click(function () {
        clearModalMasterMainPic();
        $('#hfEditMode').val('0');
        $('#modalMasterNews').modal('show');
    });

    $('#btnSaveMasterNews').click(function () {
        $('#modalMasterNews').modal('hide');
        $body = $("body");
        $body.addClass("loading");
        var validationMessage = "";
        var Title = $("#txtTitle").val();
        var DateNews = $("#txtDateNews").val();
        var Desc = $("#txtDesc").val();
        var picPath = $('#fuAttachment').val();

        if (Title.length < 1) {
            validationMessage += "Title harus di isi. \n";
        }
        if (DateNews.length < 1) {
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

    $('#modalMasterMainNewsDelete').click(function () {
        var row = $('#hfdelrow').val();
    });

    $('#tblMasterMainPic').on("click", ".btnDelete", deleteMainPic);

});

function clearModalMasterMainPic() {
    var _fileuploadcontrolId = $("#fuAttachment");
    _fileuploadcontrolId.replaceWith(_fileuploadcontrolId = _fileuploadcontrolId.clone(true));
    $("#txtTitle").val("");
    $("#txtDateNews").val("");
    $("#txtDesc").val("");
}

function Init() {
    $('#tblMasterMainPic tbody').remove();
    var dateFormat = "dd-MMM-yyyy";
    $.ajax({
        type: "POST",
        url: window.location.pathname + "/LoadMasterNews",
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
                    '<td >' + formatDate(dateFromJSON(picList[i].DateNews), dateFormat) + ' </td>' +
                    '<td >' + picList[i].NewsText + ' </td>' +
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
    $("#modalMasterNews").modal("show");
    $("#txtTitle").attr('disabled', true);
    $("#txtDateNews").val(row.children()[1].innerText)
    $("#txtDateNews").val(row.children()[2].innerText)
    $("#txtDesc").val(row.children()[3].innerText)
    $("#file").val(row.children()[4].innerText)
}

function deleteMainPic() {
    $body = $("body");
    $body.addClass("loading");
    var $element = this;
    var row = $($element).parents("tr:first");

    var masterNews = new Object();
    masterNews.Id = row.children()[0].innerText.trim();
    masterNews.Tittle = row.children()[1].innerText;
    masterNews.DateNews = row.children()[2].innerText;
    masterNews.NewsText = row.children()[3].innerText;
    masterNews.PicturePath = row.children()[4].innerText;
    masterNews.FileName = row.children()[5].innerText;

    var lastIndex = masterNews.PicturePath.lastIndexOf("\\");
    if (lastIndex >= 0) {
        masterNews.FileName = masterNews.PicturePath.substring(lastIndex + 1);
    }

    var parameter = new Object();
    parameter.fileToUpload = JSON.stringify(masterNews);

    $.ajax({
        type: "POST",
        url: window.location.pathname + "/DeleteMasterNews",
        async: false,
        cache: false,
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var Menu = response.d;
            if (Menu == "Success") {
                $("#modalMasterNews").modal("hide");
                $body.removeClass("loading");
                alert("Master News telah dihapus.")
                Init();
            }
        },
        error: function (response) {
            $("#modalMasterNews").modal("hide");
            $body.removeClass("loading");
            alert(response.responseText);
        }
    });
}

function saveMainPic() {
    //var EditMethod = true;
    //var editMode = $("#hfEditMode").val();
    //if (editMode == 0) EditMethod = false;
    //var masterNews = new Object();
    //masterNews.PicturePath = $("#fuAttachment").val();
    //masterNews.Tittle = $("#txtTitle").val();
    //masterNews.DateNews = $("#txtDateNews").val();
    //masterNews.NewsText = $("#txtDesc").val();

    //var lastIndex = masterNews.PicturePath.lastIndexOf("\\");
    //if (lastIndex >= 0) {
    //    masterNews.FileName = masterNews.PicturePath.substring(lastIndex + 1);
    //}

    //var parameter = new Object();
    //parameter.fileToUpload = JSON.stringify(masterNews);
    //parameter.isEdit = EditMethod;

    //$.ajax({
    //    type: "POST",
    //    url: window.location.pathname + "/SaveMasterNews",
    //    data: JSON.stringify(parameter),
    //    contentType: "application/json; charset=utf-8",
    //    datatype: "json",
    //    async: true,
    //    success: function (response) {
    //        var Menu = response.d;
    //        $("#modalMasterNews").modal("hide");
    //        $body.removeClass("loading");
    //        alert(Menu)
    //        Init();
    //    },
    //    error: function (response) {
    //        alert(response.responseText);
    //        $("#modalMasterNews").modal("hide");
    //        $body.removeClass("loading");
    //    }
    //});

    var DocLink = $("#fuAttachment").get(0);
    var DocFile = DocLink.files;       
    var files = document.getElementById('fuAttachment').files;

    var Tittle = $("#txtTitle").val();
    var DateNews = $("#txtDateNews").val();
    var NewsText = $("#txtDesc").val();

    var handlerurl = "/_layouts/15/GenericPortal.ashx?Method=uploadimageNews&tittle=" + Tittle + "&datenews=" + DateNews + "&text=" + NewsText;

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
            $("#modalMasterNews").modal("hide");
            $body.removeClass("loading");
            alert(Menu)
            Init();
        },
        error: function (response) {
            $body.removeClass("loading");
            alert(response.responseText);
            $("#modalMasterNews").modal("hide");
        }
    });
}