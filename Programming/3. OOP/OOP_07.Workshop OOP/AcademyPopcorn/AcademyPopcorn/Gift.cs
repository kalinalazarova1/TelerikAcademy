using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 11:
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '$' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<ShootingRacket> shootingRacket = new List<ShootingRacket>();
            if (this.IsDestroyed)
            {
                ShootingRacket newRacket = new ShootingRacket(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col - 3), 6);
                newRacket.AvailableBullets = 5;
                shootingRacket.Add(newRacket);
            }
            return shootingRacket;
        }
    }
}
