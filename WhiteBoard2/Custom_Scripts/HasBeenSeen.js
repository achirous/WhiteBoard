$(document).ready(function () {
        var element = document.getElementsByName("announcement");   //get all the announcement elements
        for (var i = 1; i <= element.length; i++) {
                //for every post return its SeenBy partial view from the controller
                (function (index) {
                    $.ajax({
                        url: "/Posts/BuildSeenBy",  //call the BuilSeenBy method
                        type: "POST",
                        target: "seenByDiv" + index,
                        data: {
                            i: index    //send the postId as parameter to the controller method
                        },
                        success: function (result) {
                            //update the approppriate seenByDiv for every post
                            $("#seenByDiv" + index).html(result);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log(errorThrown);
                        }
                    });
                })(i);
            
        }        

});


