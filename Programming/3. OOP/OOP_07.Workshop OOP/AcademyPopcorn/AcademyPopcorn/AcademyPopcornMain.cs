/*1.The AcademyPopcorn class contains an IndestructibleBlock class. Use it to create side and ceiling 
 * walls to the game. You can ONLY edit the AcademyPopcornMain.cs file.
2.The Engine class has a hardcoded sleep time (search for "System.Threading.Sleep(500)". Make the sleep
 * time a field in the Engine and implement a constructor, which takes it as an additional parameter.
3.Search for a "TODO" in the Engine class, regarding the AddRacket method. Solve the problem mentioned
 * there. There should always be only one Racket. Note: comment in TODO not completely correct
4.Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.
5.Implement a TrailObject class. It should inherit the GameObject class and should have a constructor 
 * which takes an additional "lifetime" integer. The TrailObject should disappear after a "lifetime"
 * amount of turns. You must NOT edit any existing .cs file.
6.Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of TrailObject 
 * objects. Each trail objects should last for 3 "turns". Other than that, the Meteorite ball should 
 * behave the same way as the normal ball. You must NOT edit any existing .cs file.
7.Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.
8.Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces off UnpassableBlocks
 * and will destroy any other block it passes through. The UnpassableBlock should be indestructible.
 * Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method and the
 * CollisionData class.
9.Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file
10.Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. You must
 * NOT edit any existing .cs file. Hint: what does an explosion "produce"?
11.Implement a Gift class. It should be a moving object, which always falls down. The gift shouldn't 
 * collide with any ball, but should collide (and be destroyed) with the racket. You must NOT edit any
 * existing .cs file. 
12.Implement a GiftBlock class. It should be a block, which "drops" a Gift object when it is destroyed.
 * You must NOT edit any existing .cs file. Test the Gift and GiftBlock classes by adding them through
 * the AcademyPopcornMain.cs file.
13.Implement a shoot ability for the player racket. The ability should only be activated when a Gift 
 * object falls on the racket. The shot objects should be a new class (e.g. Bullet) and should destroy
 * normal Block objects (and be destroyed on collision with any block). Use the engine and ShootPlayerRacket
 * method you implemented in task 4, but don't add items in any of the engine lists through the ShootPlayerRacket
 * method. Also don't edit the Racket.cs file. Hint: you should have a ShootingRacket class and override 
 * its ProduceObjects method.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;
            int endRow = WorldRows - 1;
            Random ranGen = new Random();

            for (int i = startCol - 1; i < endCol + 1; i++)
            {
                Block currBlock;
                int probability = ranGen.Next(0, 100);
                if (probability < 30)
                {
                    //Task 10:
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                }
                else if (probability < 60 && probability >= 30)
                {
                    //Task 12:
                    currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                }
                else
                {
                    currBlock = new Block(new MatrixCoords(startRow, i));
                }
                engine.AddObject(currBlock);

            }

            for (int i = startCol - 2; i < endCol + 2; i++)
            {
                //Task 1: IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(startRow - 1, i));
                //Task 9:
                UnpassableBlock ceiling = new UnpassableBlock(new MatrixCoords(startRow - 1, i));

                engine.AddObject(ceiling);
            }

            for (int i = startRow; i < endRow + 1; i++)
            {
                //Task 1:
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, startCol - 2));
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, endCol + 1));

                engine.AddObject(rightWall);
                engine.AddObject(leftWall);
            }

            //Task 7:
            MeteoriteBall BallOne = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(BallOne);

            //Task 9:
            //UnstoppableBall BallTwo = new UnstoppableBall(new MatrixCoords(WorldRows / 2 + 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(BallTwo);

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            //I also made two small fixes in the KeyboardInterface class to improve the racket performance
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Task 13:
            EngineShootPlayerRacket gameEngine = new EngineShootPlayerRacket(renderer, keyboard, 500);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            //Task 13:
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                 gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
