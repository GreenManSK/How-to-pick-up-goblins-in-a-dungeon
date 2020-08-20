using System.Collections.Generic;
using Dating;

namespace Characters.Enemy.Type
{
    public class YandereType : IEnemyType
    {
        private readonly Dictionary<SeductionType, float> _multipliers = new Dictionary<SeductionType, float>()
        {
            {SeductionType.Present, -1f},
            {SeductionType.PickUpLine, 0f},
            {SeductionType.Compliment, 1f},
            {SeductionType.ShowInterest, 2f},
            {SeductionType.Insult, 2f},
            {SeductionType.Attack, 0f},
        };

        public float TypeMultiplier(SeductionType seductionType)
        {
            return _multipliers[seductionType];
        }
    }
}