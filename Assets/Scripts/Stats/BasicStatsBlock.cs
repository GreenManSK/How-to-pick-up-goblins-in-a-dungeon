using System;

namespace Stats
{
    [Serializable]
    public class BasicStatsBlock
    {
        public int str = 1;
        public int con = 1;

        public float GetMaxHp()
        {
            return 5 * con;
        }
    }
}