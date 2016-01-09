$(document).ready(function () {
    var DATE_FORMAT_ENTRY = "dd-M-yy";
    Init();

});

function Init() {

    $.ajax({
        type: "POST",
        url: "/_layouts/15/GenericPortal.ashx?Method=maincategory",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Category = JSON.parse(response);
            var parentLink = '';
            var seq = ''
            var idMainKat = ''
            if (Category.length > 0) {
                for (i = 0; i < Category.length; i++) {
                    if (parentLink != Category[i].LinkAppKategoryName) {
                        seq = i + 1;
                        idMainKat = "#Main" + seq;
                        var strhtml = '<td class="td-content">' +
                                      '<div class="title-content">' + Category[i].LinkAppKategoryName + '</div>' +
                                      '<div id=Main' + seq + ' class="news-content">' +
                                      '</div>' +
                                      '</td>';
                        $(strhtml).appendTo($("#MainCategory"));
                        parentLink = Category[i].LinkAppKategoryName;
                    }
                    $("<div><a href=" + Category[i].LinkAppUrl + ">" + Category[i].LinkAppName + "</a><br /></div>").appendTo(idMainKat)
                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

    //$.ajax({
    //    type: "POST",
    //    url: "/_layouts/15/GenericPortal.ashx?Method=maincategorychild",
    //    data: "{}",
    //    contentType: "application/json; charset=utf-8",
    //    datatype: "json",
    //    async: true,
    //    success: function (response) {
    //        var CategoryChild = JSON.parse(response);
    //        if (CategoryChild.length > 0) {
    //            for (i = 0; i < CategoryChild.length; i++) {
    //                var seq = i + 1;
    //                //var strhtml = 'Tes';
    //                //$(strhtml).appendTo($("#Main1"));
    //                //$("<div>" + CategoryChild[i].LinkAppName + "<br /></div>").appendTo("#Main1")
    //                $("<div><a href=" + CategoryChild[i].LinkAppUrl + ">" + CategoryChild[i].LinkAppName + "</a><br /></div>").appendTo("#Main1")

    //            }
    //        }
    //    },
    //    error: function (response) {
    //        alert(response.responseText);
    //    }
    //});


    $.ajax({
        type: "POST",
        url: "/_layouts/15/GenericPortal.ashx?Method=news",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var News = JSON.parse(response);
            var dateFormat = "dd-MMM-yyyy";
            if (News.length > 0) {
                for (i = 0; i < News.length; i++) {
                    var seq = i + 1;                    
                    var strghtml = '<tr>' +
    				                   '<td>' +
                                            '<div class="date-content2">' + formatDate(dateFromJSON(News[i].DateNews), dateFormat) + '</div>' +
    				                   '</td>' +
    				                   '<td>' +
    					                    '<div class="small-title-content2">' +
    										'<a href=News.aspx?NewsId=' + News[i].Id + '>' + News[i].Tittle + '</a>' +
    										'</div>' +
    					                    '<div class="small-news-content2">' + News[i].NewsText + '</div>' +
                                       '</td>' +
                                   '</tr>';
                    $(strghtml).appendTo($("#NewsView"));

                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

    $.ajax({
        type: "POST",
        url: "/_layouts/15/GenericPortal.ashx?Method=event",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var Event = JSON.parse(response);
            var dateFormat = "dd-MMM-yyyy";
            if (Event.length > 0) {
                for (i = 0; i < Event.length; i++) {
                    var seq = i + 1;
                    //var data = new Date(News[i].DateNews);
                    var srghtml = '<tr>' +
    				                   '<td>' +
                                            '<div class="date-content2">' + formatDate(dateFromJSON(Event[i].DateEvent), dateFormat) + '</div>' +
    				                   '</td>' +
    				                   '<td>' +
    					                    '<div class="small-title-content2">' +
    										'<a href=Event.aspx?EventId=' + Event[i].Id + '>' + Event[i].Tittle + '</a>' +
    										'</div>' +
    					                    '<div class="small-news-content2">' + Event[i].EventText + '</div>' +
                                       '</td>' +
                                   '</tr>';
                    $(srghtml).appendTo($("#EventView"));

                }
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });


    //$.ajax({
    //    type: "POST",
    //    url: "/_layouts/15/GenericPortal.ashx?Method=mainpic",
    //    data: "{}",
    //    contentType: "application/json; charset=utf-8",
    //    datatype: "json",
    //    async: true,
    //    success: function (response) {
    //        var MainPic = JSON.parse(response);
    //        if (MainPic.length > 0) {
    //            for (i = 0; i < MainPic.length; i++) {
    //                var seq = i + 1;
    //                ////var data = new Date(News[i].DateNews);
    //                //var tohtml = '<img src=' + MainPic[i].Path + ' />';
    //                //$(tohtml).appendTo($("#slide"));
    //                $("<div><img src=" + MainPic[i].Path + " alt=images" + seq + " /></div>").appendTo($("#slide"));
    //            }
    //        }
    //        $('#slide').coinslider();
    //    },
    //    error: function (response) {
    //        alert(response.responseText);
    //    }
    //});


    $.ajax({
        type: "POST",
        url: "/_layouts/15/GenericPortal.ashx?Method=bottompic",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (response) {
            var BottomPic = JSON.parse(response);
            if (BottomPic.length > 0) {
                for (i = 0; i < BottomPic.length; i++) {
                    var seq = i + 1;
                    //var data = new Date(News[i].DateNews);
                    //var kehtml =

                    //    '<div style=display: none; >' +
                    //		'<img data-u=image src=' + BottomPic[i].Path + ' />' +
                    //	'</div>';
                    //$(kehtml).appendTo($("#BottomPic"));                    
                    //$("<div><a href=" + CategoryChild[i].LinkAppUrl + ">" + CategoryChild[i].LinkAppName + "</a><br /></div>").appendTo("#Main4")
                    $("<div style=display: none;><a href=" + BottomPic[i].LinkTo + " ><img data-u=image src=" + BottomPic[i].Path + " /></a></div>").appendTo($("#BottomPic"));
                }
            }
            jssor_1_slider_init();
        },
        error: function (response) {
            alert(response.responseText);
        }
    });


}