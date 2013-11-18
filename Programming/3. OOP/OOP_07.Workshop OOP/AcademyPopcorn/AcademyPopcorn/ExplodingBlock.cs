using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 10:
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Debris> debris = new List<Debris>();
            if (this.IsDestroyed)
            {
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col + 1), new char[,] { { '.' } }, new MatrixCoords(0,0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 1), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + 1), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row, this.topLeft.Col - 1), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 1), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
                debris.Add(new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col - 1), new char[,] { { '.' } }, new MatrixCoords(0, 0)));
            }
            return debris;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
