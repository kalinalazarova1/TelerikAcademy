// 2. Draw a circle that flies inside a box. When it reaches an edge, it should bounce that edge

window.onload = function () {
    var canvas = document.getElementsByTagName('canvas')[0],
        ctx = canvas.getContext('2d'),
        width = canvas.width,
        heigth = canvas.height,
        minX = 7,
        maxX = minX + width - 6 * 2,
        minY = 7,
        maxY = minY + heigth - 6 * 2,
        direction = 0,
        posX = minX,
        posY = Math.random() * (maxY - minY) + minY;

    function moveBall() {
        var speed = 1;              //speed in pixels for 0.1 second 
        ctx.beginPath();
        ctx.clearRect(posX - 10, posY - 10, 20, 20);
        switch (direction) {
        case 0:
            posX += speed;
            posY += speed;
            if (posX > maxX) {
                direction = 2;
            } else if (posY > maxY) {
                direction = 1;
            }
            break;
        case 1:
            posX += speed;
            posY -= speed;
            if (posX > maxX) {
                direction = 3;
            } else if (posY < minY) {
                direction = 0;
            }
            break;
        case 2:
            posX -= speed;
            posY += speed;
            if (posX < minX) {
                direction = 0;
            } else if (posY > maxY) {
                direction = 3;
            }
            break;
        case 3:
            posX -= speed;
            posY -= speed;
            if (posX < minX) {
                direction = 1;
            } else if (posY < minY) {
                direction = 2;
            }
            break;
        }
        ctx.strokeStyle = '#000';
        ctx.arc(posX, posY, 6, 0, Math.PI * 2);
        ctx.stroke();
        ctx.fill();
        ctx.closePath();
        setTimeout(function () { moveBall(); }, 10);
    }

    ctx.strokeStyle = '#000';
    ctx.beginPath();
    ctx.fillStyle = '#97ff00';
    ctx.lineWidth = 1;
    ctx.arc(posX, posY, 6, 0, Math.PI * 2);
    ctx.stroke();
    ctx.fill();
    ctx.closePath();
    moveBall();
};