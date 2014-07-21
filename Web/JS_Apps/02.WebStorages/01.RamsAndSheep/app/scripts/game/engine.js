define(['scripts/game/ui', 'scripts/game/game', 'scripts/game/storage'], function (ui, game, storage) {
    'use strict';
    var engine = (function () {
        function run() {
            var moves = 0,
                hidden = game.getHiddenNumber(),                    // generate secret number
                button = document.getElementById('check');

            function onButtonClick() {
                var player,
                    scores,
                    result,
                    number = ui.getInput('div#left .digit');
                if (!(game.validateNumber(number))) {               // if entered number is not valid
                    alert('Invalid input!');
                } else {
                    result = game.getCurrentResult(hidden, number); // calculate rams and sheep (current result)
                    moves++;
                    if (result.rams === 4) {      // game over if number is guessed and save score
                        ui.renderFinalMessage(moves);
                        player = ui.getPlayerName();
                        storage.addScore(player, moves);
                        scores = storage.getScores();
                        ui.renderScores(scores);
                        return;
                    }
                    ui.renderCurrentResult(result, 'div#right');       // if number is not guessed - render current result
                }
            }

            button.addEventListener('click', onButtonClick, false);
        }

        return {
            run: run
        };
    }());

    return engine;
});