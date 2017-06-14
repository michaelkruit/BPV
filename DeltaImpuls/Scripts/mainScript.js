var url = window.location.pathname;
var searchValue = $('#SearchString').val();
var locationValue = $('#locationFilter').val();

function GetData() {
    searchValue = $('#SearchString').val();
    locationValue = $('#locationFilter').val();
    categorieValue = $('#categorieFilter').val();
}

$('#locationFilter').change(function () {
    GetData();
    $.ajax({
        type: "GET",
        url: url,
        data: { "searchString": searchValue, "locationFilter": locationValue, "categorieFilter": categorieValue },
        success: function (result) {
            $('.table tbody').html($(result).find('.table tbody tr'));
            //$('.paginations').html($(result).find('.paginations'));
        },
        error: function (result) {
            alert("Error!");
        }
    });
});

$('#categorieFilter').change(function () {
    GetData();
    $.ajax({
        type: "GET",
        url: url,
        data: { "searchString": searchValue, "locationFilter": locationValue, "categorieFilter": categorieValue },
        success: function (result) {
            $('.table tbody').html($(result).find('.table tbody tr'));
            //$('.paginations').html($(result).find('.paginations'));
        },
        error: function (result) {
            alert("Error!");
        }
    });
});

$('#SearchString').keypress(function (e) {
    GetData();
    if (e.which == 13) {
        $.ajax({
            type: "GET",
            url: url,
            data: { "searchString": searchValue, "locationFilter": locationValue, "categorieFilter": categorieValue },
            success: function (result) {
                $('.table tbody').html($(result).find('.table tbody tr'));
            }
        });
    }
});