var url = window.location.pathname;
var searchValue = $('#SearchString').val();

function GetData() {
    searchValue = $('#SearchString').val();
}

$('#SearchString').keypress(function (e) {
    GetData();
    if (e.which == 13) {
        $.ajax({
            type: "GET",
            url: url,
            data: { "searchString": searchValue },
            success: function (result) {
                $('.table tbody').html($(result).find('.table tbody tr'));
                //$('.paginations').html($(result).find('.paginations'));
            }
        });
    }
});