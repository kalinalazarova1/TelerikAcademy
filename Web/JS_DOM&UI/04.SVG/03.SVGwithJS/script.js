window.onload = function () {

    function rectangle(x, y, width, height, fillColor) {
        var svg = document.getElementById('screen'),
            svgRect = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
        svgRect.setAttribute('height', height);
        svgRect.setAttribute('width', width);
        svgRect.setAttribute('x', x);
        svgRect.setAttribute('y', y);
        svgRect.setAttribute('fill', fillColor);

        svg.appendChild(svgRect);
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

    function image(x, y, width, height, src) {
        var svg = document.getElementById('screen'),
            svgImg = document.createElementNS('http://www.w3.org/2000/svg', 'image');
        svgImg.setAttribute('height', height);
        svgImg.setAttribute('width', width);
        svgImg.setAttributeNS('http://www.w3.org/1999/xlink', 'href', src);
        svgImg.setAttribute('x', x);
        svgImg.setAttribute('y', y);

        svg.appendChild(svgImg);
    }

    function smallRect(x, y, color, textContent, imageSrc) {
        rectangle(x, y, 100, 100, color);
        text(x + 10, y + 90, textContent);

        if (imageSrc !== undefined) {
            image(x + 20, y + 5, 70, 70, imageSrc);
        }
    }

    function bigRect(x, y, color, textContent, imageSrc) {
        rectangle(x, y, 205, 100, color);
        text(x + 10, y + 90, textContent);

        if (imageSrc !== undefined) {
            image(x + 50, y + 5, 70, 70, imageSrc);
        }
    }

    text(50, 90, 'Start', '#fff', 30, 'Consolas');

    smallRect(50, 150, "#2b86f0", "Store", "/images/store.jpg");
    smallRect(155, 150, "#66b311", "xBox", "/images/xbox.jpg");
    bigRect(260, 150, "#be1c4b", "Photos", "/images/photos.jpg");
    bigRect(470, 150, "#009118", "Calendar", "");
    text(620, 190, '12', '#fff', 40, 'Segoe WP');
    text(620, 200, 'Monday', '#fff', 9, 'Segoe WP');
    bigRect(720, 150, "#5e3ab8", "Music", "/images/music.jpg");
    image(920, 150, 100, 100, "/images/sketchbook-logo.jpg");

    smallRect(50, 255, "#5d39b5", "Maps", "/images/maps.jpg");
    smallRect(155, 255, "#2b86f0", "Internet", "/images/ie.jpg");
    bigRect(260, 255, "#5d39b5", "Messaging", "/images/messages.jpg");
    bigRect(470, 255, "#d9532d", "Contacts", "images/Contacts.png");
    bigRect(720, 255, "#009017", "Finance", "/images/finance.jpg");
    bigRect(930, 255, "#0062a6", "");

    bigRect(50, 360, "#da552c", "Videos", "/images/video.jpg");
    bigRect(260, 360, "#009a18", "Mail", "/images/mail.jpg");
    image(470, 360, 100, 100, "images/pinball.jpg");
    smallRect(575, 360, "#2e88ee", "Solitaire", "/images/solitare.jpg");
    smallRect(720, 360, "#d7512a", "Reader", "/images/reader.jpg");
    smallRect(825, 360, "#012a6a", "");
    text(835, 380, 'Windows', 'blue', 16, 'Segoe WP');
    text(835, 400, 'Explorer', 'blue', 16, 'Segoe WP');
    smallRect(930, 360, "#267beb", "SkyDrive", "/images/skydrive.jpg");

    bigRect(50, 465, "#1f7982", "Desktop");
    bigRect(260, 465, "#2d8bef", "Weather", "/images/weather.jpg");
    smallRect(470, 465, "#bc1c4a", "Camera", "/images/camera.jpg");
    smallRect(575, 465, "#5aa518", "Xbox Companion", "/images/xboxcomp.jpg");
    image(720, 465, 205, 100, "/images/wordpress.jpg");
};