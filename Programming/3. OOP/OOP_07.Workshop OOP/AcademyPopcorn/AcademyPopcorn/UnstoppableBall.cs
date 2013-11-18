using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 8:
    public class UnstoppableBall : Ball //could only be stopped by unpassable block, destroys normal blocks and passes through indestructible blocks but do not destructs them
    {
        public const char Symbol = '@';

        public new const string CollisionGroupString = "unstoppable ball";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = UnstoppableBall.Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "indestructible block" ||
                otherCollisionGroupString == "unpassable block" || otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var collisionObjectString in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionObjectString == "unpassable block")
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            }
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
    }
}
