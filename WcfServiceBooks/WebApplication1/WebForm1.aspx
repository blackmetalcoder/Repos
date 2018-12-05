<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script>
        $(document).ready(function () {
            var q = 'http://localhost:63479//BookService.svc/DoWork';
   /* var data;
    var postdata = {};
    var data_obj = { "BoolValue": "true",  "StringValue": 'Nisse' }
    postdata["value"] = data_obj; 
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/xml; charset=utf-8", //
        //data: JSON.stringify(postdata),
        dataType: "json",
        success: function (data) { alert(data); }, //data
        error: function (a, b, c) { alert(a.statusCode); } //a
    });*/
            $.ajax({
                url: q,
    dataType: "text",
    success: function(data) {
      data = JSON.parse(data);
      success(data);
    }
  });

function success(data) {
  alert(data);
}

});
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
