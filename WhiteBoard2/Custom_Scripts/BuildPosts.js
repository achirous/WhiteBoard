$(document).ready(function () {
    $.ajax({
        //call BuildPostTable method and return all the announcements
        url: "/Posts/BuildPostTable",
        success: function (result) {
            $("#tableDiv").html(result);
        }
    });
});