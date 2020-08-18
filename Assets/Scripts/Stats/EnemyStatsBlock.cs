using System;

namespace Stats
{
    [Serializable]
    public class EnemyStatsBlock : BasicStatsBlock
    {
        public int resistance = 1;

        public float GetMaxResistance()
        {
            return 5 * resistance;
        }
    }
}