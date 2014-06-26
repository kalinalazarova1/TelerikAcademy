// 2.Create a module that works with moving div elements. Implement functionality for:
// Add new moving div element to the DOM
// The module should generate random background, font and border colors for the div element
// All the div elements are with the same width and height
// The movements of the div elements can be either circular or rectangular
// The elements should be moving all the time

var movingShapes = (function () {
    'use strict';
    function randomColor() {
        return "rgb(" + parseInt(Math.random() * 256, 10) + "," + parseInt(Math.random() * 256, 10) + "," + parseInt(Math.random() * 256, 10) + ")";
    }

    function moveEllipseDiv(angle, singleDiv) {
        var r1 = 80,         //first radius (height) of ellipse path
            r2 = 120,        //second radius (width) of ellipse path
            xCenter = 200,   //x location of ellipse path centre on screen
            yCenter = 400,   //y location of ellipse path centre on screen
            x = Math.floor(xCenter + (r1 * Math.cos(angle))),
            y = Math.floor(yCenter + (r2 * Math.sin(angle)));

        angle = angle + 0.01;//speed 0.01 radian per 20 miliseconds
        singleDiv.style.top = x + "px"; //set divs new coordinates
        singleDiv.style.left = y + "px"; //set divs new coordinates

        setTimeout(function () { //repeats the function moveEllipseDiv after 20 miliseconds 
            moveEllipseDiv(angle, singleDiv);
        }, 20);
    }

    function moveRectDiv(dir, offset, singleDiv) {
        var xStart = 100,       //left of the rectangle
            yStart = 800,       //top of the rectangle
            rectSideA = 400,    //rectangle orbit sides
            rectSideB = 200,
            x,
            y;

        offset += 1;            //speed 1 pixel per 20 miliseconds
        if ((offset === rectSideA && dir % 2 === 0) || (offset === rectSideB && dir % 2 === 1)) {
            dir++;
            dir %= 4;
            offset = 0;
        }

        switch (dir) {
        case 0:
            y = yStart + offset;
            x = xStart;
            break;
        case 1:
            x = xStart + offset;
            y = yStart + rectSideA;
            break;
        case 2:
            y = yStart + rectSideA - offset;
            x = xStart + rectSideB;
            break;
        case 3:
            x = xStart + rectSideB - offset;
            y = yStart;
            break;
        }
        singleDiv.style.top = x + "px"; //set divs new coordinates
        singleDiv.style.left = y + "px"; //set divs new coordinates

        setTimeout(function () { //repeats the function moveRectDiv after 20 miliseconds 
            moveRectDiv(dir, offset, singleDiv);
        }, 20);
    }

    function add(shape) {
        var wrapper = document.getElementById("wrapper"),
            singleDiv = document.createElement("div");
        singleDiv.className = "circle";
        singleDiv.style.backgroundColor = randomColor();
        singleDiv.style.color = randomColor();
        singleDiv.style.border = "2px solid " + randomColor();
        singleDiv.innerHTML = "DIV";
        wrapper.appendChild(singleDiv);
        if (shape === 'rect') {
            moveRectDiv(0, 0, singleDiv);
        } else if (shape === 'ellipse') {
            moveEllipseDiv(0, singleDiv);
        }
    }

    return {
        add: add
    };
}());
