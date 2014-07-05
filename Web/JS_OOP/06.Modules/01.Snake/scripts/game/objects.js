///<reference path="../libs/require.js" />
define(function () {
    var objects = (function () {
        var Food,
            Snake = (function () {
                function Snake() {
                    this._segmentCount = 5;
                    this._segment = 20;
                    this._direction = 0;
                    this._body = [];
                    this._forClear = {};
                }

                Snake.prototype.head = function () {
                    return this._body[0];
                };

                Snake.prototype.chageDirection = function (pressedKeyCode) {
                    this._direction = pressedKeyCode - 37;
                };

                Snake.prototype.size = function () {
                    return this._segmentCount;
                };

                Snake.prototype.getSegment = function () {
                    return this._segment;
                };

                Snake.prototype.generate = function (width, height) {
                    var i,
                        startX = parseInt(width / this._segment / 2, 10) * this._segment,
                        startY = parseInt(height / this._segment / 2, 10) * this._segment;
                    for (i = 0; i < this._segmentCount; i++) {
                        this._body.push({ x: startX + i * this._segment, y: startY });
                    }
                };

                Snake.prototype.move = function () {
                    this._forClear = {};
                    var j;
                    this._forClear.x = this._body[this._segmentCount - 1].x;
                    this._forClear.y = this._body[this._segmentCount - 1].y;
                    for (j = this._segmentCount - 1; j >= 1; j--) {
                        this._body[j].x = this._body[j - 1].x;
                        this._body[j].y = this._body[j - 1].y;
                    }
                    switch (this._direction) {
                    case 0:
                        this._body[0].x -= this._segment;
                        break;
                    case 1:
                        this._body[0].y -= this._segment;
                        break;
                    case 2:
                        this._body[0].x += this._segment;
                        break;
                    case 3:
                        this._body[0].y += this._segment;
                        break;
                    }
                };

                return Snake;
            }());

        Food = (function () {
            function Food() {
                this._x = 0;
                this._y = 0;
                this._segment = 20;
            }

            Food.prototype.generate = function (width, height) {
                this._x = parseInt(Math.random() * width / this._segment, 10) * this._segment;
                this._y = parseInt(Math.random() * height / this._segment, 10) * this._segment;
            }

            return Food;
        }());
            return {
                Snake: Snake,
                Food: Food
            };
        }());

    return objects;
});