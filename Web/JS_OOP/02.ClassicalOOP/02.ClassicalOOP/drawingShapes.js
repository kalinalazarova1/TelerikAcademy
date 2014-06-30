﻿// 1.Create a module for drawing shapes using Canvas. Implement the following shapes:
// Rect, by given position (X, Y) and size (Width, Height)
// Circle, by given center position (X, Y) and radius (R)
// Line, by given from (X1, Y1) and to (X2, Y2) positions

var CanvasDrawer = (function () {
    var ctx;
    function CanvasDrawer(selector, args) {
        if (!(this instanceof arguments.callee)) {
            return new CanvasDrawer(selector, args);
        }
        this.stroke = args.stroke || 'black';
        this.line = args.line || 1;
        this.fill = args.fill || 'white';
        var container = document.querySelector(selector),
            canvas;
        if (!container) {
            throw new ReferenceError('Container selector is not defined!');
        }
        canvas = document.createElement('canvas');
        canvas.setAttribute('width', args.width || 1000);
        canvas.setAttribute('height', args.height || 500);
        container.appendChild(canvas);
        ctx = canvas.getContext('2d');
    }

    CanvasDrawer.prototype.drawLine = function (line) {
        ctx.beginPath();
        ctx.moveTo(line.startX, line.startY);
        ctx.lineTo(line.endX, line.endY);
        ctx.closePath();
        ctx.lineWidth = this.line;
        ctx.strokeStyle = this.stroke;
        ctx.stroke();
    };

    CanvasDrawer.prototype.drawCircle = function (circle) {
        ctx.beginPath();
        ctx.fillStyle = this.fill;
        ctx.strokeStyle = this.stroke;
        ctx.lineWidth = this.line;
        ctx.arc(circle.x, circle.y, circle.radius, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fill();
        ctx.stroke();
    };

    CanvasDrawer.prototype.drawRect = function (rect) {
        ctx.fillStyle = this.fill;
        ctx.lineWidth = this.line;
        ctx.strokeStyle = this.stroke;
        ctx.fillRect(rect.x, rect.y, rect.width, rect.height);
        ctx.strokeRect(rect.x, rect.y, rect.width, rect.height);
    };

    return CanvasDrawer;
}());

var shapes = (function () {
    function Rect(x, y, width, height) {
        if (!(this instanceof arguments.callee)) {
            return new Rect(x, y, width, height);
        }
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    function Circle(x, y, radius) {
        if (!(this instanceof arguments.callee)) {
            return new Circle(x, y, radius);
        }
        this.x = x;
        this.y = y;
        this.radius = radius;
    }
    function Line(startX, startY, endX, endY) {
        if (!(this instanceof arguments.callee)) {
            return new Line(startX, startY, endX, endY);
        }
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
    }
    return {
        Rect: Rect,
        Circle: Circle,
        Line: Line
    };
}());