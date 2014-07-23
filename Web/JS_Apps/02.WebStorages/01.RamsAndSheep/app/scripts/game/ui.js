///<reference path="../libs/jquery.js" />

define(['scripts/libs/jquery'], function () {
    'use strict';
    var ui = (function () {
        function getInput(selector) {
            var inputNumber = $(selector).val();
            $(selector).val('');
            return inputNumber;
        }

        function renderFinalMessage(currentScore) {
            $('body').html('<p class="end">YOU WON!!!<br>' + 'Your score is: ' + currentScore + ' points.</p>');
        }

        function renderScores(scores) {
            var i,
                $scoreBoard = $('<tbody>');
            $scoreBoard.attr('id', 'score_board');
            $scoreBoard.html('<tr><th>SCORE BOARD:</th></tr>');
            for (i = 0; i < (scores.length < 10 ? scores.length : 10); i++) {
                $scoreBoard.html($scoreBoard.html() +
                        '<tr><td>' +
                        (i + 1) +
                        '. ' + scores[i].name +
                        '</td><td>' +
                        scores[i].score +
                        ' points</td></tr>'
                    );
            }
            $scoreBoard.html($scoreBoard.html() + '</tbody>');
            $('body').append($('<table>').append($scoreBoard));
        }

        function getPlayerName() {
            return toSaveString(prompt('Please enter your name: ', 'anonymous'));
        }

        function toSaveString(str) {
            str = str.replace(/</g, '&lt;');
            str = str.replace(/>/g, '&gt;');
            return str;
        }

        function renderCurrentResult(currentNumber, selector) {
            var j,
                $result,
                $current = $('<div>')
                    .append($('<div>')
                        .html(currentNumber.number + ': ')
                        .addClass('resultNumber'));
            $result = $('<div>').addClass('resultImages');
            for (j = 0; j < currentNumber.rams; j++) {
                $('<img>')
                    .attr('src', 'app/images/ram.png')
                    .css({
                        'width': '30px',
                        'height': '30px'
                    })
                    .appendTo($result);
            }

            for (j = 0; j < currentNumber.sheep; j++) {
                $('<img>')
                    .attr('src', 'app/images/sheep.png')
                    .css({
                        'width': '30px',
                        'height': '30px'
                    })
                    .appendTo($result);
            }

            $result.appendTo($current);
            $(selector).append($current);
        }

        return {
            getInput: getInput,
            renderFinalMessage: renderFinalMessage,
            renderScores: renderScores,
            getPlayerName: getPlayerName,
            renderCurrentResult: renderCurrentResult
        };
    }());

    return ui;
});