using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 6:
    public class MeteoriteBall : Ball
    {
        private const int TrailLength = 3;
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trail = new List<TrailObject>();
            trail.Add(new TrailObject(this.TopLeft, new char[,] { { '*' } }, TrailLength));
            return trail;
        }
    }
}
