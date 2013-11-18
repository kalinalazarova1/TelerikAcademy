using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 13:
    public class ShootingRacket : Racket
    {
        public bool IsFired { get; set; }

        public int AvailableBullets { get; set; }

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.IsFired = false;
            this.AvailableBullets = 0;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Bullet> shot = new List<Bullet>();
            if (this.IsFired && this.AvailableBullets > 0)
            {
                this.AvailableBullets--;
                IsFired = false;
                shot.Add(new Bullet(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + this.Width / 2)));
            }
            return shot;
        }
    }
}
