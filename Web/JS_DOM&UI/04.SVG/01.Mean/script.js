window.onload = function () {
    function logo() {
        var svg = document.getElementById('screen');
        svg.innerHTML += '<g transform="translate(0.000000,62.000000) scale(0.100000,-0.100000)" fill="#000000" stroke="none"><path fill="#282828" d="M650 -1350 c-41 -24 -41 -25 -41 -84 0 -32 3 -59 8 -59 21 1 42 30 42 58 0 20 7 35 18 41 26 14 40 1 44 -38 2 -21 11 -39 26 -49 l22 -14 0 63 0 64 -39 21 -39 21 -41 -24z" /><path fill="white" d="M845 -1350 c-36 -19 -38 -23 -38 -69 0 -47 1 -49 44 -72 l44 -23 41 27 c35 23 41 33 41 62 0 39 -33 81 -71 89 -14 3 -39 -2 -61 -14z" /><path fill="#282828" d="M1120 -1280 c-2 -48 -6 -58 -20 -55 -10 1 -36 -7 -58 -18 -38 -20 -40 -22 -40 -69 0 -47 1 -49 44 -72 l44 -23 41 27 41 27 0 107 c0 89 -3 108 -17 119 -29 21 -32 17 -35 -43z" /><path fill="#282828" d="M1250 -1350 c-30 -18 -33 -24 -33 -68 0 -46 2 -49 40 -71 36 -20 42 -21 67 -8 l27 15 -42 21 c-42 22 -53 46 -30 69 14 14 48 -2 48 -24 0 -12 4 -12 25 2 34 22 31 38 -9 63 -41 26 -53 26 -93 1z" /></g>';
    }

    function circle(cx, cy, r, fillColor) {
        var svg = document.getElementById('screen'),
            svgCir = document.createElementNS('http://www.w3.org/2000/svg', 'circle');
        svgCir.setAttribute('r', r);
        svgCir.setAttribute('cx', cx);
        svgCir.setAttribute('cy', cy);
        svgCir.setAttribute('fill', fillColor);

        svg.appendChild(svgCir);
    }

    function text(x, y, content, color, fontSize, fontFamily, fontWeight) {
        fontSize = fontSize || 11;
        fontFamily = fontFamily || "Consolas";
        fontWeight = fontWeight || "normal";
        color = color || '#fff';

        var svg = document.getElementById('screen'),
            svgText = document.createElementNS('http://www.w3.org/2000/svg', 'text');

        svgText.innerHTML = content;
        svgText.setAttribute('x', x);
        svgText.setAttribute('y', y);
        svgText.setAttribute('fill', color);
        svgText.setAttribute('font-size', fontSize);
        svgText.setAttribute('font-family', fontFamily);
        svgText.setAttribute('font-weight', fontWeight);

        svg.appendChild(svgText);
    }

    function path(stroke, fill, strokeWidth, d) {
        var svg = document.getElementById('screen'),
            svgPath = document.createElementNS('http://www.w3.org/2000/svg', 'path');

        svgPath.setAttribute('stroke', stroke);
        svgPath.setAttribute('fill', fill);
        svgPath.setAttribute('stroke-width', strokeWidth);
        svgPath.setAttribute('d', d);

        svg.appendChild(svgPath);
    }

    circle(100, 50, 50, "#3E3F37");
    path("#5EB14A", "#5EB14A", "1", "M 100 25 C70 50 100 80 100 80");
    path("#449644", "#449644", "1", "M 100 25 C130 50 100 80 100 80");
    circle(100, 100, 50, "#282828");
    text(55, 100, 'express', 'white', 25, 'Arial', 'normal');
    circle(100, 150, 50, "#E23337");
    path("lightgray", "#B63032", "3", "M 100 120 L130 130 L100 250");
    path("lightgray", "#E23337", "3", "M 100 120 L70 130 L100 250");
    path("white", "#E23337", "5", "M 100 130 l-20 50");
    path("lightgrey", "#E23337", "5", "M 100 130 l20 50");
    circle(100, 200, 50, "#8EC74E");
    text(10, 70, "M", "#3E3F37", 30, "Arial Black", "bold");
    text(10, 120, "E", "#282828", 30, "Arial Black", "bold");
    text(10, 170, "A", "#E23337", 30, "Arial Black", "bold");
    text(10, 220, "N", "#8EC74E", 30, "Arial Black", "bold");
    logo();
};