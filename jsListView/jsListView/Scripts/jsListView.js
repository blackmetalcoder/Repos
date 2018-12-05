$(document).on('click', '.jsDividerHead', function () {
    var isVisible = $('.jsListItem').css('display') === 'none';
    if (isVisible) {
        $('.jsListItem').toggle('hide');
    }
    else {
        $('.jsListItem').toggle('show');
        $('html, body').animate({
            scrollTop: ($('#Superettan').offset().top)
        }, 500);
    }
});
$(document).ready(function () {
    $("#results").click(function () {
        getTemplate();
    });
});
function getResults() {
    alert('Hej!');
    var datum = '2018-03-15';
    $.ajax({
        type: "GET",
        url: "https://resultatservice.azurewebsites.net/api/Fixtures?StartDatum=" + datum,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        crossDomain: true,
        success: successFunction,
        error: function (msg) {
            alert(msg.statusText);
        }
    });
    function successFunction(data) {
        var html = '';
        $.each(data, function (index, item) {
            var namn = item.Time;
            var pris = item.Date;
            var Hemmalag = item.HomeTeam;
            var Bortalag = item.AwayTeam;

        });
    }
}
function hamta() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "https://coresoccerapi.azurewebsites.net/api/values?StartDatum=2018-09-29",
        "method": "GET",
        "headers": {
            "Cache-Control": "no-cache",
            "Postman-Token": "ad704be6-0c52-4045-a2cf-0153700bd2a6"
        }
    };

    $.ajax(settings).done(function (response) {
        console.log(response);
    });
}
function getTemplate(){
    //var html = $.parseHTML('Allalbums.html');
    //alert(html);
    
}
