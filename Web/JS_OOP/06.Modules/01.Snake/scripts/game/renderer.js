///<reference path="objects.js" />
///<reference path="../libs/require.js" />

define(['game/objects'], function (objects) {
    var Renderer = (function () {
        var SNAKE_COLOR = '#1C8E1C',
            HEAD_COLOR = '#8fc800',
            FOOD_COLOR = '#FF0000';

        function Renderer() {
            var canvas = document.getElementsByTagName('canvas')[0];
            this._ctx = canvas.getContext('2d');
            this._width = canvas.width;
            this._height = canvas.height;
        }

        function DrawCircle(x, y, radius, fill) {
            this._ctx.fillStyle = fill;
            this._ctx.beginPath();
            this._ctx.arc(x, y, radius, 0, 2 * Math.PI);
            this._ctx.closePath();
            this._ctx.fill();
        }

        Renderer.prototype.render = function (gameObject) {
            var i;
            //snake
            if (gameObject instanceof objects.Snake) {
                for (i = 1; i < gameObject._segmentCount; i++) {
                    DrawCircle.call(this, gameObject._body[i].x + gameObject._segment / 2, gameObject._body[i].y + gameObject._segment / 2, gameObject._segment / 2, SNAKE_COLOR);
                }
                this._ctx.clearRect(gameObject._forClear.x - 1, gameObject._forClear.y - 1, gameObject._segment + 1, gameObject._segment + 1);
                DrawCircle.call(this, gameObject._body[0].x + gameObject._segment / 2, gameObject._body[0].y + gameObject._segment / 2, gameObject._segment / 2, HEAD_COLOR);
            } else {
            //food
                DrawCircle.call(this, gameObject._x + gameObject._segment / 2, gameObject._y + gameObject._segment / 2, gameObject._segment / 2, FOOD_COLOR);
            }
        };

        return Renderer;
    }());

    return Renderer;
});