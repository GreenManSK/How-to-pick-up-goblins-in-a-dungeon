using System.Collections.Generic;
using Dating;

namespace Characters.Enemy.Type
{
    public class TsundereType : IEnemyType
    {
        private readonly Dictionary<SeductionType, float> _multipliers = new Dictionary<SeductionType, float>()
        {
            {SeductionType.Present, 2f},
            {SeductionType.PickUpLine, -1f},
            {SeductionType.Compliment, 2f},
            {SeductionType.ShowInterest, 1f},
            {SeductionType.Insult, 1f},
            {SeductionType.Attack, -0.5f},
        };

        public float TypeMultiplier(SeductionType seductionType)
        {
            return _multipliers[seductionType];
        }
    }
}