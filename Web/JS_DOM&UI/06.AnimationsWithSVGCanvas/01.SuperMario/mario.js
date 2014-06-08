// 1.Create a walking Super Mario
// Super Mario must be walking indefinitely from left to right on the screen
// The background must be created using SVG
// Additional requirements:
// You can use sprites from this link
// Use Canvas for Super Mario
// Use SVG for the background
// You can use Raphael and/or KineticJS, or native Canvas/SVG APIs

window.onload = function () {
    var marioLayer = new Kinetic.Layer(),
        marioImageObj = new Image(),
        stage,
        mario,
        frameCount;
    marioImageObj.onload = function () {
        mario = new Kinetic.Sprite({
            x: 650,
            y: 448,
            width: 50,
            image: marioImageObj,
            animation: 'stayRight',
            animations: {

                stayRight: [
                    155, 0, 40, 66
                ],
                stayLeft: [
                    115, 0, 40, 66
                ],
                walkLeft: [
                    80, 0, 40, 66,
                    40, 0, 40, 66,
                    0, 0, 40, 66
                ],
                walkRight: [
                    190, 0, 40, 66,
                    230, 0, 40, 66,
                    270, 0, 40, 66
                ]
            },
            frameRate: 7,
            frameIndex: 0
        });

        marioLayer.add(mario);

        stage = new Kinetic.Stage({
            width: 1300,
            height: 600,
            container: 'container'
        });
        stage.add(marioLayer);

        mario.start();

        frameCount = 0;

        mario.on('frameIndexChange', function () {
            if ((mario.animation() === 'walkRight') && ++frameCount > 4) {
                mario.move({
                    x: 10,
                    y: 0
                });
                mario.animation('stayRight');
                frameCount = 0;
            } else if ((mario.animation() === 'walkLeft') && ++frameCount > 4) {
                mario.move({
                    x: -10,
                    y: 0
                });
                mario.animation('stayLeft');
                frameCount = 0;
            }
        });

        function onKeyDown(ev) {
            if (ev.keyCode === 37) {
                mario.animation('walkLeft');
            } else if (ev.keyCode === 39) {
                mario.animation('walkRight');
            }
        }

        document.body.addEventListener('keydown', onKeyDown, false);

    };
    marioImageObj.src = 'images/mario.gif';
};