using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 12:
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Gift> gifts = new List<Gift>();
            if (this.IsDestroyed)
            {
                Gift gift = new Gift(this.topLeft);
                gifts.Add(gift);
            }
            return gifts;
        }

        public override void Update()
        {
            ProduceObjects();
        }
    }
}
