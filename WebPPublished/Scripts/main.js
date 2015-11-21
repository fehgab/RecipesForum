$(document).ready(function() {
    $("#ingredients").cleditor();
    $("#howtoprepare").cleditor();
    $("#newcomment").cleditor();

    "use strict";
    var RecipeForum = window.RecipeForum || {};
    RecipeForum.GetComments = function (url, recipeId) {
        /// <summary>
        /// Betölti az adott könyvhöz tartozó kommenteket.
        /// </summary>
        $.ajax({
            url: url,
            data: { recipeId: recipeId },
            dataType: "html",
            type: "GET",
            cache: false,
        }).done(function (data, textStatus, jqXHR) {
            $("#comment").html(data);
        });
    };
});