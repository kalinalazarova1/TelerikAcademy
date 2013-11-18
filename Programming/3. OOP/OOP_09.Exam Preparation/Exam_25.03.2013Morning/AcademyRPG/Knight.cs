using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        private const int KnightStrength = 100;

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = KnightStrength;
        }

        public int AttackPoints
        {
            get { return KnightStrength; }
        }

        public int DefensePoints
        {
            get { return KnightStrength; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
