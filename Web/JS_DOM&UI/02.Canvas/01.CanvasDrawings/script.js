// 1. Draw the following graphics using canvas:...

function drawLine(ctx, startX, startY, endX, endY) {
    ctx.moveTo(startX, startY);
    ctx.lineTo(endX, endY);
    ctx.stroke();
}

function drawEllipse(cxt, centerX, centerY, width, height, tilt, startAngle, endAngle, stroke, fill, line) {
    var i,
        xPos,
        yPos;
    cxt.beginPath(); //tilt, startAngle, endAngle are in radians
    for (i = startAngle; i <= endAngle; i += 0.01) {
        xPos = centerX - (height * Math.sin(i)) * Math.sin(tilt) + (width * Math.cos(i)) * Math.cos(tilt);
        yPos = centerY + (width * Math.cos(i)) * Math.sin(tilt) + (height * Math.sin(i)) * Math.cos(tilt);

        if (i === 0) {
            cxt.moveTo(xPos, yPos);
        } else {
            cxt.lineTo(xPos, yPos);
        }
    }
    cxt.fillStyle = fill;
    cxt.fill();
    cxt.lineWidth = line;
    cxt.strokeStyle = stroke;
    cxt.stroke();
}

var canvas = document.getElementsByTagName('canvas')[0];
var ctx = canvas.getContext('2d');
ctx.strokeStyle = '#398394';                    //draws the bicycle
ctx.fillStyle = '#95cdd9';
ctx.lineWidth = 1;
drawLine(ctx, 280, 515, 250, 485);
ctx.beginPath();
ctx.arc(200, 500, 37, 0, 2 * Math.PI);
ctx.stroke();
ctx.fill();
ctx.beginPath();
ctx.arc(340, 500, 37, 0, 2 * Math.PI);
ctx.stroke();
ctx.fill();
ctx.beginPath();
ctx.arc(265, 500, 10, 0, 2 * Math.PI);
ctx.stroke();
ctx.fillStyle = '#555555';
ctx.fill();
drawLine(ctx, 340, 500, 334, 448);
drawLine(ctx, 334, 448, 265, 500);
drawLine(ctx, 200, 500, 265, 500);
drawLine(ctx, 200, 500, 248, 452);
drawLine(ctx, 248, 452, 265, 500);
drawLine(ctx, 334, 448, 248, 452);
drawLine(ctx, 334, 448, 331, 422);
drawLine(ctx, 248, 452, 240, 428);
drawLine(ctx, 225, 428, 255, 428);
drawLine(ctx, 331, 422, 351, 402);
drawLine(ctx, 331, 422, 301, 432);

drawEllipse(ctx, 200, 300, 50, 45, 0, 0, 2 * Math.PI, '#275a65', '#95cdd9', 1);      //draws the face
drawEllipse(ctx, 200, 260, 55, 10, 0, 0, 2 * Math.PI, '#292826', '#3f6c98', 1);
drawEllipse(ctx, 203, 250, 27, 10, 0, 0, Math.PI, '#292826', '#3f6c98', 1);
drawLine(ctx, 230, 250, 230, 190);
drawLine(ctx, 175, 250, 175, 190);
ctx.fillRect(175, 190, 55, 60);
drawEllipse(ctx, 203, 190, 27, 10, 0, 0, 2 * Math.PI, '#292826', '#3f6c98', 1);
drawEllipse(ctx, 190, 320, 20, 7, 0.05 * Math.PI, 0, 2 * Math.PI, '#275a65', '#95cdd9', 1);
drawLine(ctx, 190, 303, 180, 303);
drawLine(ctx, 180, 303, 190, 282);
drawEllipse(ctx, 172, 282, 8, 5, 0, 0, 2 * Math.PI, '#275a65', '#95cdd9', 1);
drawEllipse(ctx, 208, 282, 8, 5, 0, 0, 2 * Math.PI, '#275a65', '#95cdd9', 1);
drawEllipse(ctx, 170, 282, 5, 1, Math.PI / 2, 0, 2 * Math.PI, '#275a65', '#275a65', 3);
drawEllipse(ctx, 206, 282, 5, 1, Math.PI / 2, 0, 2 * Math.PI, '#275a65', '#275a65', 3);

ctx.beginPath();
ctx.rect(600, 250, 220, 190);               //draws the house
ctx.fillStyle = '#9c6161';
ctx.strokeStyle = '#000000';
ctx.lineWidth = 2;
ctx.fill();
ctx.stroke();
ctx.beginPath();
ctx.moveTo(600, 250);
ctx.lineTo(710, 130);
ctx.lineTo(820, 250);
ctx.closePath();
ctx.fill();
ctx.stroke();
ctx.fillStyle = '#000000';
ctx.fillRect(620, 270, 35, 25);
ctx.fillRect(657, 270, 35, 25);
ctx.fillRect(657, 297, 35, 25);
ctx.fillRect(620, 297, 35, 25);
ctx.fillRect(725, 270, 35, 25);
ctx.fillRect(762, 270, 35, 25);
ctx.fillRect(762, 297, 35, 25);
ctx.fillRect(725, 297, 35, 25);
ctx.fillRect(725, 345, 35, 25);
ctx.fillRect(762, 345, 35, 25);
ctx.fillRect(762, 372, 35, 25);
ctx.fillRect(725, 372, 35, 25);
ctx.beginPath();
drawLine(ctx, 685, 440, 685, 380);
drawEllipse(ctx, 658, 380, 27, 15, 0, Math.PI, Math.PI * 2, '#000000', '#9c6161', 2);
drawLine(ctx, 630, 440, 630, 380);
drawLine(ctx, 658, 365, 658, 440);
drawEllipse(ctx, 667.5, 420, 3, 3, 0, 0, Math.PI * 2, '#000000', '#9c6161', 2);
drawEllipse(ctx, 647.5, 420, 3, 3, 0, 0, Math.PI * 2, '#000000', '#9c6161', 2);
ctx.fillRect(745, 150, 20, 70);
drawLine(ctx, 745, 220, 745, 150);
drawLine(ctx, 765, 220, 765, 150);

ctx.save();
ctx.scale(1, 0.3);
ctx.beginPath();
ctx.arc(755, 500, 10, 0, Math.PI * 2);
ctx.fillStyle = '#9c6161';
ctx.fill();
ctx.lineWidth = 3;
ctx.stroke();
ctx.closePath();
ctx.restore();