$(document).ready(function () {
    var divs = document.getElementsByClassName("commentsList"); //get all the elements with the class name of commentsList
    for (var i = 1; i < divs.length+1; i++) {   //loop through all the comment elements
        var div = document.getElementById("commentsDiv" + i);   //get each comment element
        (function (index) {
            $.ajax({
                //populates each comment element with the partial view rendered by the controller method for that id
                url: "/Posts/BuildCommentsTable",   //the controller method called
                type: "POST",
                target: "commentsDiv" + index,  //where the result of the controller method will go
                data: {
                    id: index   //the id that corresponds to the postId to which the comment list will be sent to
                },
                success: function (result) {
                    $("#commentsDiv" + index).html(result);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        })(i);
        
    }
})