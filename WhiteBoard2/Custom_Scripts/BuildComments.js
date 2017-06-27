$(document).ready(function () {
    $(".NewComment").keyup(function (e) {
        //if enter is pressed
        if (e.keyCode === 13) {
            e.preventDefault();
            var self = $(this);
            var id = self.attr("id");   //get the id of the current element  
            var value = self.val(); //get the value of the current element
            var token = $('input[name="__RequestVerificationToken"]').val(); //get the verification token
            $.ajax({
                /*send the verification token, the id, and the value obtained above to the 
                AJAXComment method in PostsController*/
                url: "/Posts/AJAXComment",
                data: {
                    __RequestVerificationToken: token,
                    id: parseInt(id),
                    value: value
                },
                type: "POST",
                success: function (result) {
                    //put the result of the controller method in to the appropriate commentsDiv
                    $("#commentsDiv"+id).html(result);   
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(errorThrown);
                    alert("Invalid Input");
                }
            });
        }

       
    });
});