// 1.Create the Snake game using the Revealing module pattern. Design the game such that it has at least three modules.

///<reference path="libs/require.js" />
///<reference path="game/objects.js" />
///<reference path="game/engine.js" />

require(['game/engine'], function (GameEngine) {
    var game = new GameEngine();
    game.run();
});