$(document).ready(function () {
    var DATE_FORMAT_ENTRY = "dd-M-yy";
    Init();

});

function Init() {
    var Id = getUrlVars()["EventId"];
    if (Id == undefined || Id == '') {
        alert("Event can't load, please go to Home and click on the news item");
        window.location = "http://pgekpwfe001/SitePages/Home.aspx";
        return;
    }

    var parameter = new Object();
    parameter.EventId = Id;

    $.ajax({
        type: "POST",
        url: "/_layouts/15/PGE.Portal/AdminPortalPage.aspx/LoadEvent",
        data: JSON.stringify(parameter),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var strhtml = '<span class="newpic" id="EventPic"> ' +
                            '<img src=' + response.d[0].PicturePath + ' itemprop=image align=left width=700px />' +
                            '</span>';
            $(strhtml).appendTo($("#EventPic"));

            var strhtmlText = '<p> ' +
                                response.d[0].EventText +
                                '</p>';
            $(strhtmlText).appendTo($("#EventText"));
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}