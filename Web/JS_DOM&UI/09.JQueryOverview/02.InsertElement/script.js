// 2.Using jQuery implement functionality to insert a DOM element before or after another element

function insertElementAfter(element, selector) {
    $(element).insertAfter($(selector));
}

function insertElementBefore(element, selector) {
    $(element).insertBefore($(selector));
}

function insertElement() {
    if ($(this).attr('id') === 'before') {
        insertElementBefore('<p>Inserted paragraph</p>', $('#line'));
    } else {
        insertElementAfter('<p>Inserted paragraph</p>', $('#line'));
    }
}

$(document).ready(function () {
    $('#before').on('click', insertElement);
    $('#after').on('click', insertElement);
});