/// <reference path="jquery.min.js"

$.fn.tabs = function () {
    $this = $(this);
    $('.tab-item-content').hide();
    $('.tab-item').click(function (ev) {
        $('.tab-item').removeClass('current');
        $(ev.target)
            .parent()
            .addClass('current')
            .css({
                'background': '#ccc',
                'border-bottom': '1px solid #ccc'
            });
        $('.current .tab-item-content').show();
    });
    $('.tab-item')
        .first()
        .addClass('current');
    $('#tabs-container')
        .addClass('tabs-container');
    $('.current .tab-item-content').show();
    return this;
};