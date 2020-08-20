using System.Collections.Generic;
using Dating;

namespace Characters.Enemy.Type
{
    public class NormalType : IEnemyType
    {
        private readonly Dictionary<SeductionType, float> _multipliers = new Dictionary<SeductionType, float>()
        {
            {SeductionType.Present, 1f},
            {SeductionType.PickUpLine, 2f},
            {SeductionType.Compliment, 2f},
            {SeductionType.ShowInterest, 1f},
            {SeductionType.Insult, -1f},
            {SeductionType.Attack, -1f},
        };

        public float TypeMultiplier(SeductionType seductionType)
        {
            return _multipliers[seductionType];
        }
    }
}