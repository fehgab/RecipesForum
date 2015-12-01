$(document).ready(function() {
    $("#ingredients").cleditor();
    $("#howtoprepare").cleditor();
    $("#newcomment").cleditor();
});

$(function () {
    $('#datetimepicker3').datetimepicker({
        format: 'LT'
    });
});

var RecipeForum = window.RecipeForum || {};
RecipeForum.GetComments = function (url, recipeId, pageNumber) {
    $.ajax({
        url: url,
        data: { recipeId: recipeId, pageNumber : pageNumber},
        type: "GET",
    }).done(function (data, textStatus, jqXHR) {
        //console.log(data);
        $("#comments").html(data);
    });
};


RecipeForum.CreateCommentField = function (url, recipeId) {
    $.ajax({
        url: url,
        data: {recipeId : recipeId},
        type: "GET",
    }).done(function (data, textStatus, jqXHR) {
        //console.log(data);
        $("#create_comment").html(data);
    });
};

RecipeForum.EditComment = function (url, commentId) {
    $.ajax({
        url: url,
        data: { commentId: commentId },
        type: "GET",
    }).done(function (data, textStatus, jqXHR) {
        //console.log(data);
        $("#create_comment").html(data);
    });
};