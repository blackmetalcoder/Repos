function getArtist(id) {
    $.ajax({
        type: "GET",
        url: "http://cdmolnet.se/CDService.asmx/getArtistElectron?userID=" + 1,
        crossDomain: true,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successvinyl,
        error: function (msg) {
            alert(msg.statusText);
        }
    });
    function successvinyl(data) {
        try {
            var obj = JSON.parse(data.d);
            var shtml = '<ul data-role="list">';
            $.each(obj, function (index, item) {
                shtml += '<li data-role="listview" id="lstA" data-id="' + item.artist + '">' + item.artist + '</li>';
            });
            shtml += '</ul>';

            $("#list").html(shtml);

            var jobCount = obj.length;
            $('.list-count').text(jobCount + ' Artister/grupper');
        }
        catch (err) {
            // gör inget
        }
    }
}