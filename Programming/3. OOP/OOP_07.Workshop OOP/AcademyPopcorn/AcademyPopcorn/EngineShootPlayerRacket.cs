using System;

namespace AcademyPopcorn
{
    //Task 4:
    public class EngineShootPlayerRacket : Engine
    {
        ShootingRacket playerRacket;

        public EngineShootPlayerRacket(IRenderer renderer, IUserInterface userInterface, int timeSleep)
            : base(renderer, userInterface, timeSleep)
        {
        }

        public EngineShootPlayerRacket(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
            //Task 13:
            this.playerRacket.IsFired = true;
        }

        public override void AddObject(GameObject obj) //overriding of this method is important for task 13 in order to get access to the fields of the current racket
        {
            if (obj is ShootingRacket)
            {
                ShootingRacket newRacket = obj as ShootingRacket;
                this.playerRacket = newRacket;
            }
            base.AddObject(obj);
        }
    }
}
