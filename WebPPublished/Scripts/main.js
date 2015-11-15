$(document).ready(function() {
    $.ajax({
        url: '@Url.Action("LogOff", "Account")',
        type: "POST",
        cache: false,
    }).done(function(data, textStatus, jqXHR) {
        //$("#comments").html(data);
    });
    $("#input").cleditor();
});