define(function () {
    'use strict';
    var storage = (function () {
        function addScore(player, moves) {
            var i,
                worstKey,
                scoresTable = localStorage.getItem('RamSheepScore');
            if (!scoresTable) {
                scoresTable = [];
            } else {
                scoresTable = JSON.parse(scoresTable);
            }
            scoresTable.push({
                name: player,
                score: moves
            });
            if (scoresTable.length <= 10) {
                localStorage.setItem('RamSheepScore', JSON.stringify(scoresTable));
                return;
            }
            worstKey = 0;
            for (i = 1; i < scoresTable.length; i++) {
                if (scoresTable[i].score < scoresTable[worstKey].score) {
                    worstKey = i;
                }
            }
            scoresTable.splice(worstKey, 1);
            localStorage.setItem('RamSheepScore', JSON.stringify(scoresTable));
        }

        function getScores() {
            var i,
                scoresTable,
                arr = [];
            scoresTable = JSON.parse(localStorage.getItem('RamSheepScore'));
            for (i = 0; i < scoresTable.length; i++) {
                arr[i] = scoresTable[i];
            }
            arr.sort(function (first, second) { return first.score - second.score; });
            return arr;
        }

        return {
            addScore: addScore,
            getScores: getScores
        };
    }());

    return storage;
});