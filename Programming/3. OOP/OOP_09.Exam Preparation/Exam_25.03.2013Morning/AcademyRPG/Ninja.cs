using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private const int NinjaHitPoints = 1;

        private int attackPoints;

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = NinjaHitPoints;
            this.AttackPoints = 0;
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            if (availableTargets.Count > 0)
            {
                int maxIndex = 0;
                int max = availableTargets[0].HitPoints;
                for (int i = 0; i < availableTargets.Count; i++)
                {
                    if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner && availableTargets[i].HitPoints > max)
                    {
                        max = availableTargets[i].HitPoints;
                        maxIndex = i;
                    }
                }
                return maxIndex;
            }
            else
            {
                return -1;
            }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
