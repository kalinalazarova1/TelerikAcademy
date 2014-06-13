// 4.Implement functionality to change the background color of a web page
// i.e. select a color from a color picker and set this color as the background color of the page

(function () {
    $('input').on('change', function () { $('body').css('background-color', $('input').val()); });
})();