///<reference path="../libs/require.js" />
define(function () {
    function savePlayer(currentScore) {
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
        scoresTable.push({ name: playerName, score: currentScore });
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

    function gameOver(currentScore) {
        document.body.innerHTML = '<p>GAME OVER<br>' + 'Your score is: ' + currentScore + ' points.';
        savePlayer(currentScore);
        printScores();
    }

    return gameOver;
});