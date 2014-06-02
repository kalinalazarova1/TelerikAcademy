// *Create the famous game "Snake"
// The snake is a sequence of rectangles/ellipses
// The snake can move left, right, up or down
// The snake dies if it reaches any of the edges or when it tries to eat itself
// A food should be generated
// When the snake eats the food, it grows and new food is generated at random position
// Implement the game using OOP and canvas
// Implement a high-score board, kept in localStorage

window.onload = function () {
    var food,
        snake,
        canvas = document.getElementsByTagName('canvas')[0],
        ctx = canvas.getContext('2d'),
        width = canvas.width,
        heigth = canvas.height,
        interval = 500,
        movement;

    function onArrowPressed(ev) {
        snake.chageDirection(ev.keyCode);
    }

    function savePlayer() {
        var worstKey,
            playerName = prompt('Please enter your name: ', 'anonymous'),
            i,
            scoresTable = localStorage.getItem('scores');
        document.body.removeEventListener('keydown', savePlayer, false);
        if (!scoresTable) {
            scoresTable = [];
        } else {
            scoresTable = JSON.parse(scoresTable);
        }
        scoresTable.push({ name: playerName, score: snake.size() });
        if (scoresTable.length <= 5) {
            localStorage.setItem('scores', JSON.stringify(scoresTable));
            return;
        }
        worstKey = 0;
        for (i = 1; i < scoresTable.length; i++) {
            if (scoresTable[i].score < scoresTable[worstKey].score) {
                worstKey = i;
            }
        }
        scoresTable.splice(worstKey, 1);
        localStorage.setItem('scores', JSON.stringify(scoresTable));
    }

    function printScores() {
        var scoreBoard,
            scores,
            i;
        function orderScores() {
            var scoresTable,
                arr = [];
            scoresTable = JSON.parse(localStorage.getItem('scores'));
            for (i = 0; i < scoresTable.length; i++) {
                arr[i] = scoresTable[i];
            }
            arr.sort(function (x, y) { return y.score - x.score; });
            return arr;
        }
        scoreBoard = document.createElement('table');
        scoreBoard.id = 'score_board';
        scoreBoard.innerHTML = '<tbody><tr><td>SCORE BOARD:</tr></th>';
        scores = orderScores();
        for (i = 0; i < (scores.length < 5 ? scores.length : 5); i++) {
            scoreBoard.innerHTML += '<tr><td>' + (i + 1) + '. ' + scores[i].name + '</td><td>' + scores[i].score + ' points</td></tr>';
        }
        document.body.appendChild(scoreBoard);
    }

    function gameOver() {
        document.body.innerHTML = '<p>GAME OVER<br>' + 'Your score is: ' + snake.size() + ' points.<br>Press a key to exit...</p>';
        document.body.addEventListener('keydown', savePlayer, false);
        savePlayer();
        printScores();
    }

    snake = (function () {
        var segmentCount = 5,
            segment = 20,
            direction = 0,
            color = '#1C8E1C',
            headColor = '#8fc800',
            body = [];
        function isOutside() {
            var minX = 0,
                maxX = minX + width - segment,
                minY = 0,
                maxY = minY + heigth - segment;

            if (body[0].x < minX || body[0].y < minY || body[0].x > maxX || body[0].y > maxY) {
                return true;
            }
            return false;
        }
        function isBitten() {
            var j;
            for (j = 1; j < segmentCount - 1; j++) {
                if (body[j].x === body[0].x && body[j].y === body[0].y) {
                    return true;
                }
            }
            return false;
        }
        return {
            head: function () {
                return body[0];
            },
            chageDirection: function (pressedKeyCode) {
                direction = pressedKeyCode - 37;
            },
            size: function () {
                return segmentCount;
            },
            getSegment: function () {
                return segment;
            },
            generate: function () {
                var i,
                    startX = Number.parseInt(canvas.width / segment / 2) * segment,
                    startY = Number.parseInt(canvas.height / segment / 2) * segment;
                for (i = 0; i < segmentCount; i++) {
                    body.push({ x: startX + i * segment, y: startY });
                }
            },
            render: function () {
                var i;
                ctx.fillStyle = color;
                for (i = 1; i < segmentCount; i++) {
                    ctx.fillRect(body[i].x, body[i].y, segment, segment);
                }
                ctx.fillStyle = headColor;
                ctx.fillRect(body[0].x, body[0].y, segment, segment);
            },
            move: function () {
                var forClear = {},
                    j;
                forClear.x = body[segmentCount - 1].x;
                forClear.y = body[segmentCount - 1].y;
                ctx.clearRect(forClear.x - 1, forClear.y - 1, segment + 2, segment + 2);
                for (j = segmentCount - 1; j >= 1; j--) {
                    body[j].x = body[j - 1].x;
                    body[j].y = body[j - 1].y;
                }
                switch (direction) {
                case 0:
                    body[0].x -= segment;
                    break;
                case 1:
                    body[0].y -= segment;
                    break;
                case 2:
                    body[0].x += segment;
                    break;
                case 3:
                    body[0].y += segment;
                    break;
                }
                if (isOutside() || isBitten()) {
                    clearInterval(movement);
                    gameOver();
                }
                if (food.isEaten()) {
                    segmentCount++;
                    if (segmentCount % 5 === 0) {
                        interval -= 100;
                    }
                    body.push(forClear);
                    while (food.isOverSnake()) {
                        food.generate();
                    }
                    food.render();
                }
                ctx.fillStyle = headColor;
                ctx.fillRect(body[0].x, body[0].y, segment, segment);
                ctx.fillStyle = color;
                ctx.fillRect(body[1].x, body[1].y, segment, segment);
            },
            isOverFood: function (foodX, foodY) {
                var i;
                for (i = 0; i < body.length; i++) {
                    if (body[i].x === foodX && body[i].y === foodY) {
                        return true;
                    }
                }
                return false;
            }
        };
    }());

    food = (function () {
        var x = 0,
            y = 0,
            color = '#FF0000';
        return {
            generate: function () {
                x = Number.parseInt(Math.random() * canvas.width / snake.getSegment()) * snake.getSegment();
                y = Number.parseInt(Math.random() * canvas.height / snake.getSegment()) * snake.getSegment();
            },
            render: function () {
                ctx.fillStyle = color;
                ctx.fillRect(x, y, snake.getSegment(), snake.getSegment());
            },
            isEaten: function () {
                if (Math.abs(x - snake.head().x) < snake.getSegment() && Math.abs(y - snake.head().y) < snake.getSegment()) {
                    return true;
                }
                return false;
            },
            isOverSnake: function () {
                return snake.isOverFood(x, y);
            }
        };
    }());

    snake.generate();
    snake.render();
    food.generate();
    food.render();
    document.addEventListener('keydown', onArrowPressed, false);
    movement = setInterval(snake.move, interval);
};