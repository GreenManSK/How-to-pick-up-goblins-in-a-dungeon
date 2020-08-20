using System.Collections.Generic;
using Dating;

namespace Characters.Enemy.Type
{
    public class KuudereType : IEnemyType
    {
        private readonly Dictionary<SeductionType, float> _multipliers = new Dictionary<SeductionType, float>()
        {
            {SeductionType.Present, 2f},
            {SeductionType.PickUpLine, 2f},
            {SeductionType.Compliment, 2f},
            {SeductionType.ShowInterest, 0f},
            {SeductionType.Insult, -1f},
            {SeductionType.Attack, -1f},
        };

        public float TypeMultiplier(SeductionType seductionType)
        {
            return _multipliers[seductionType];
        }
    }
}