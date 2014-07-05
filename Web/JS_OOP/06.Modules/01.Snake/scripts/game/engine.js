///<reference path="objects.js" />
///<reference path="renderer.js" />
///<reference path="score.js" />
///<reference path="../libs/require.js" />

define(['game/objects', 'game/renderer', 'game/score'], function (objects, Renderer, gameOver) {
    var INTERVAL = 500,
        GameEngine;
    GameEngine = (function () {
        function GameEngine() {
            this._snake = new objects.Snake();
            this._food = new objects.Food();
            this._renderer = new Renderer();
            this._movement = null;
        }

        function isSnakeOverFood(food) {
            var i;
            for (i = 0; i < this._snake._body.length; i++) {
                if (this._snake._body[i].x === food._x &&
                        this._snake._body[i].y === food._y) {
                    return true;
                }
            }
            return false;
        }

        function isFoodEaten() {
            if (Math.abs(this._food._x - this._snake.head().x) < this._snake.getSegment() &&
                    Math.abs(this._food._y - this._snake.head().y) < this._snake.getSegment()) {
                return true;
            }
            return false;
        }

        function isSnakeOutside() {
            var minX = 0,
                maxX = minX + this._renderer._width - this._snake._segment,
                minY = 0,
                maxY = minY + this._renderer._height - this._snake._segment;

            if (this._snake._body[0].x < minX ||
                    this._snake._body[0].y < minY ||
                    this._snake._body[0].x > maxX ||
                    this._snake._body[0].y > maxY) {
                return true;
            }
            return false;
        }

        function isSnakeBitten() {
            var j;
            for (j = 1; j < this._snake._segmentCount - 1; j++) {
                if (this._snake._body[j].x === this._snake._body[0].x && this._snake._body[j].y === this._snake._body[0].y) {
                    return true;
                }
            }
            return false;
        }

        function detectCollision() {
            if (isSnakeOutside.call(this) || isSnakeBitten.call(this)) {
                clearInterval(this._movement);
                gameOver.call(null, this._snake._segmentCount);
            }
            if (isFoodEaten.call(this)) {
                this._snake._segmentCount++;
                this._snake._body.push(this._snake._forClear);
                while (isSnakeOverFood.call(this, this._food)) {
                    this._food.generate(this._renderer._width, this._renderer._height);
                }
                this._renderer.render(this._food);
            }
            this._renderer.render(this._snake);
        }

        function nextScene() {
            this._snake.move();
            detectCollision.call(this);
        }

        GameEngine.prototype.run = function () {
            var self = this;
            this._snake.generate(this._renderer._width, this._renderer._height);
            this._food.generate(this._renderer._width, this._renderer._height);
            this._renderer.render(this._snake);
            this._renderer.render(this._food);
            document.addEventListener('keydown', function (ev) { self._snake.chageDirection(ev.keyCode); }, false);
            this._movement = setInterval(function () { nextScene.call(self); }, INTERVAL);
        };

        return GameEngine;
    }());

    return GameEngine;
});
