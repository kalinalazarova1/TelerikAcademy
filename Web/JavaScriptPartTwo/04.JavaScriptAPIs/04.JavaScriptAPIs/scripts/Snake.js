// *Create the famous game "Snake"
// The snake is a sequence of rectangles/ellipses
// The snake can move left, right, up or down
// The snake dies if it reaches any of the edges or when it tries to eat itself
// A food should be generated
// When the snake eats the food, it grows and new food is generated at random position
// Implement the game using OOP and canvas
// Implement a high-score board, kept in localStorage

onload = function () {
    var food,
        snake;

    function onArrowPressed(ev) {
        snake.chageDirection(ev.keyCode);
    }

    snake = function () {
        var segmentCount = 5;
        var segment = 20;
        var direction = 0;
        var color = '#1C8E1C';
        var body = [];
        function isOutside () {
            var minX = 0,
                maxX = minX + width - segment,
                minY = 0,
                maxY = minY + heigth - segment;

            if (body[0].x < minX || body[0].y < minY || body[0].x > maxX || body[0].y > maxY) {
                return true;
            }
            return false;
        }
        function isBitten () {
            for (var j = 1; j < segmentCount - 1; j++) {
                if (body[j].x === body[0].x && body[j].y === body[0].y) {
                    return true;
                }
            }
            return false;
        }
        return {
            head: function(){
                return body[0];
            },
            chageDirection : function(pressedKeyCode){
                direction = pressedKeyCode - 37;
            },
            size: function() {
                return segmentCount;
            },
            getSegment: function(){
                return segment;
            },
            generate: function () {
                var i,
                    startX = parseInt(canvas.width / segment / 2) * segment,
                    startY = parseInt(canvas.height / segment / 2) * segment;
                for (i = 0; i < segmentCount; i++) {
                    body.push({ x: startX + i * segment, y: startY });
                }
            },
            render: function () {
                ctx.fillStyle = color;
                for (i = 0; i < segmentCount; i++) {
                    ctx.fillRect(body[i].x, body[i].y, segment, segment);
                }
            },
            move: function () {
                var forClear = {};
                forClear.x = body[segmentCount - 1].x;
                forClear.y = body[segmentCount - 1].y;
                ctx.clearRect(forClear.x - 1, forClear.y - 1, segment + 2, segment + 2);
                for (var j = segmentCount - 1; j >= 1; j--) {
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
                ctx.fillStyle = color;
                ctx.fillRect(body[0].x, body[0].y, segment, segment);
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
    }();

    food = function () {
        var x = 0;
        var y = 0;
        var color = '#FF0000';
        return {
            generate: function () {
                x = parseInt(Math.random() * canvas.width / snake.getSegment()) * snake.getSegment();
                y = parseInt(Math.random() * canvas.height / snake.getSegment()) * snake.getSegment();
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
    }();

    function gameOver() {
        document.body.innerHTML = '<p>GAME OVER<br>' + 'Your score is: ' + snake.size() + ' points.<br>Press a key to exit...</p>';
        document.body.addEventListener('keydown', savePlayer, false);
        savePlayer();
        printScores();

        function savePlayer() {
            document.body.removeEventListener('keydown', savePlayer, false);
            var playerName = prompt('Please enter your name: ', 'anonymous');
            var scoresTable = localStorage.getItem('scores');
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
            var worstKey = 0;
            for (var i = 1; i < scoresTable.length; i++) {
                if (scoresTable[i].score < scoresTable[worstKey].score) {
                    worstKey = i;
                }
            }
            scoresTable.splice(worstKey, 1);
            localStorage.setItem('scores', JSON.stringify(scoresTable));
        }

        function printScores() {
            function orderScores() {
                arr = [];
                var scoresTable = JSON.parse(localStorage.getItem('scores'));
                for (var i = 0; i < scoresTable.length; i++) {
                    arr[i] = scoresTable[i];
                }
                arr.sort(function (x, y) { return y.score - x.score; });
                return arr;
            }
            var scoreBoard = document.createElement('table');
            scoreBoard.id = 'score_board';
            scoreBoard.innerHTML = '<tbody><tr><td>SCORE BOARD:</tr></th>';
            var scores = orderScores();
            for (var i = 0; i < (scores.length < 5 ? scores.length : 5); i++) {
                scoreBoard.innerHTML += '<tr><td>' + (i + 1) + '. ' + arr[i].name + '</td><td>' + arr[i].score + ' points</td></tr>';
            }
            document.body.appendChild(scoreBoard);
        }
    }

    var canvas = document.getElementsByTagName('canvas')[0];
    var ctx = canvas.getContext('2d');
    var width = canvas.width;
    var heigth = canvas.height;
    var interval = 500;
    snake.generate();
    snake.render();
    food.generate();
    food.render();   
    document.addEventListener('keydown', onArrowPressed, false);
    var movement = setInterval(snake.move, interval);
};