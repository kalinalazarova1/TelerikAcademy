define(function () {
    'use strict';
    var game = (function () {
        var START_NUMBER = 1000,
            END_NUMBER = 9999;

        function hasRepeatedDigits(str) {
            var j,
                matches;
            for (j = 0; j < str.length; j++) {
                matches = str.match(new RegExp(str[j], 'g'));
                if (matches.length > 1) {
                    return true;
                }
            }
            return false;
        }

        function validateNumber(num) {
            num = Number(num, '10');
            if (!isNaN(num) &&
                    num > START_NUMBER &&
                    num < END_NUMBER &&
                    !hasRepeatedDigits(num.toString())) {
                return true;
            }
            return false;
        }

        function getCurrentResult(hidden, input) {
            var i,
                rams = 0,
                sheep = 0;
            hidden = hidden.toString();
            for (i = 0; i < input.length; i++) {
                if (hidden[i] === input[i]) {
                    rams++;
                } else if (hidden.indexOf(input[i]) >= 0) {
                    sheep++;
                }
            }

            return {
                number: input,
                rams: rams,
                sheep: sheep
            };
        }

        function getHiddenNumber() {
            var hidden = 0;
            while (hidden < START_NUMBER || hasRepeatedDigits(hidden.toString())) {
                hidden = Math.floor(Math.random() * (END_NUMBER - START_NUMBER)) + START_NUMBER;
            }
            return hidden;
        }

        return {
            getCurrentResult: getCurrentResult,
            getHiddenNumber: getHiddenNumber,
            validateNumber: validateNumber
        };
    }());

    return game;
});
