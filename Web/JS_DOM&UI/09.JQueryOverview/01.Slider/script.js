// 1.Create a slider control using jQuery
// The slider can have many slides
// Only one slide is visible at a time
// Each slide contains HTML code
// i.e. it can contain images, forms, divs, headers, links, etc…
// Implement functionality for changing the visible slide after 5 seconds
// Create buttons for next and previous slide

var slider = function (slides) {
    var isStartedShow = false,
        interval,
        i,
        $wrapper = $('#wrapper');

    function moveOneSlide(ev) {
        var dir,
            $current = $('.selected')
                .removeClass('selected')
                .hide();
        if (!ev) {
            dir = 'next';
        } else {
            dir = ev.target.id;
        }
        if (dir === 'next') {
            if ($current.next().length !== 0) {
                $current.next()
                    .addClass('selected')
                    .show();
            } else {
                $('.slide').first()
                    .addClass('selected')
                    .show();
            }
        } else {
            if ($current.prev().length !== 0) {
                $current.prev()
                    .addClass('selected')
                    .show();
            } else {
                $('.slide').last()
                    .addClass('selected')
                    .show();
            }
        }
    }

    function slideShow() {
        $('#next').off('click', moveOneSlide);
        $('#prev').off('click', moveOneSlide);
        if (!isStartedShow) {
            interval = window.setInterval(moveOneSlide, 1000);
            isStartedShow = true;
        } else {
            clearInterval(interval);
            $('#next').on('click', moveOneSlide);
            $('#prev').on('click', moveOneSlide);
            isStartedShow = false;
        }
    }

    for (i = 0; i < slides.length; i++) {
        $wrapper.append(
            $('<div>')
                .addClass('slide')
                .html(slides[i])
                .css('position', 'absolute')
                .css('left', '200')
                .css('top', '100')
                .hide()
        );
    }

    $('.slide')
        .first()
        .addClass('selected')
        .show();

    $('body').append(
        $('<button></button>')
            .css('width', '150')
            .css('height', '50')
            .css('margin-top', '350px')
            .css('margin-left', '10px')
            .text('Next')
            .attr('id', 'next')
    );

    $('body').append(
        $('<button></button>')
            .css('width', '150')
            .css('height', '50')
            .css('margin-left', '20px')
            .text('Previous')
            .attr('id', 'prev')
    );

    $('body').append(
        $('<button></button>')
            .css('width', '150')
            .css('height', '50')
            .css('margin-left', '20px')
            .text('Slide Show')
            .attr('id', 'show')
    );

    $(document).ready(function () {
        $('#next').on('click', moveOneSlide);
        $('#prev').on('click', moveOneSlide);
        $('#show').on('click', slideShow);
    });
};