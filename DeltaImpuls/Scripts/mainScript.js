var url = window.location.pathname;
var searchValue = $('#SearchString').val();
var locationValue = $('#locationFilter').val();
var categorieValue = $('#categorieFilter').val();

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
            $('.paginations').html($(result).find('.paginations'));
            $('.amount').html($(result).find('.amount'));
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
            $('.paginations').html($(result).find('.paginations'));
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
                $('.paginations').html($(result).find('.paginations'));
            }
        });
    }
});

$(function () {
    if (!Modernizr.inputtypes.date) {
        $('input[type=date]').datepicker({
            dateFormat: 'yy-mm-dd'
        }
         );
    }
});