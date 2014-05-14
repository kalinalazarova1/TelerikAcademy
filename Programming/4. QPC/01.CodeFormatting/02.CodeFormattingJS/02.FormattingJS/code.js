function menuChangeVisability() {
    'use strict';
    var b = navigator.appName,
        addScroll = false,
        pX = 0,
        pY = 0,
        theLayer;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    function popTip() {
        if (b === "Netscape") {
            theLayer = document.layers.ToolTip;
            if ((pX + 120) > window.innerWidth) {
                pX = window.innerWidth - 150;
            }

            theLayer.left = pX + 10;
            theLayer.top = pY + 15;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.ToolTip;
            if (theLayer) {
                pX = event.x - 5;
                pY = event.y;
                if (addScroll) {
                    pX = pX + document.body.scrollLeft;
                    pY = pY + document.body.scrollTop;
                }

                if ((pX + 120) > document.body.clientWidth) {
                    pX = pX - 150;
                }

                theLayer.style.pixelLeft = pX + 10;
                theLayer.style.pixelTop = pY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function mouseMove(evn) {
        if (b === "Netscape") {
            pX = evn.pageX - 5;
            pY = evn.pageY;
        } else {
            pX = event.x - 5;
            pY = event.y;
        }

        if (b === "Netscape") {
            if (document.layers.ToolTip.visibility === 'show') {
                popTip();
            }
        } else {
            if (document.all.ToolTip.style.visibility === 'visible') {
                popTip();
            }
        }
    }

    document.onmousemove = mouseMove;
    if (b === "Netscape") {
        document.captureEvents(event.mouseMove);
    }

    function hide(selector) {   //substitutes the functions hideMenu1, hideMenu2 and hideToolTip
        if (b === "Netscape") {
            document.layers[selector].visibility = 'hide';
        } else {
            document.all[selector].style.visibility = 'hidden';
        }
    }

    function show(selector) {   //substitutes the functions showMenu1 and showMenu2
        if (b === "Netscape") {
            theLayer = document.layers[selector];
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all[selector];
            theLayer.style.visibility = 'visible';
        }
    }
}