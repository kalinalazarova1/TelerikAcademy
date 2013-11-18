using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int GiantAttackPoints = 150;
        private const int GiantDefensePoints = 80;
        private const int GiantHitPoints = 200;

        private bool hasGatheredStone;

        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = GiantHitPoints;
            this.hasGatheredStone = false;
            this.AttackPoints = GiantAttackPoints;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return GiantDefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!hasGatheredStone)
                {
                    this.AttackPoints += 100;
                    this.hasGatheredStone = true;
                }
                return true;
            }

            return false;
        }
    }
}
