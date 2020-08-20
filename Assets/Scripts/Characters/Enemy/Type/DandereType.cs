using System.Collections.Generic;
using Dating;

namespace Characters.Enemy.Type
{
    public class DandereType : IEnemyType
    {
        private readonly Dictionary<SeductionType, float> _multipliers = new Dictionary<SeductionType, float>()
        {
            {SeductionType.Present, 2f},
            {SeductionType.PickUpLine, -1f},
            {SeductionType.Compliment, 1f},
            {SeductionType.ShowInterest, 2f},
            {SeductionType.Insult, -1f},
            {SeductionType.Attack, -1f},
        };

        public float TypeMultiplier(SeductionType seductionType)
        {
            return _multipliers[seductionType];
        }
    }
}