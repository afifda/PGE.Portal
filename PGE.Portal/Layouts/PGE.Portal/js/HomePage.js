$(document).ready(function () {
    Init();
});

function Init() {
    $.ajax({
        type: "POST",
        url: "/_layouts/15/PGE.Portal/AdminPortalPage.aspx/LoadMasterKategoriApp",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Category = response.d;
            if (Category > 0) {
                for (i = 0; i < Category.length; i++) {
                    var seq = i + 1;
                    var strhtml = '<tr id="CategoryRow_"' + seq + '>' +
                    '<td style = "display:none">' + Category[i].LinkAppKategoryName + ' </td>' +
                    '<td >' + Category[i].LinkAppKategoryName + ' </td>' +
                    '</tr>';
                    $(strhtml).appendTo($("#tblMainCategory"));
                }
            }
        },
        error: function (response) {
        alert(response.responseText);
    }
    });
}