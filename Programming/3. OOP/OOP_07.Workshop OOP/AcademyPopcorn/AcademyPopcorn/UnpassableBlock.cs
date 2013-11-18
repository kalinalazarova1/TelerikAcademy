using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 8: The unpassable block stops all kind of balls and could not be destructed and it inherits indestructible block
    public class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassable block";

        public new const char Symbol = '+';

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
