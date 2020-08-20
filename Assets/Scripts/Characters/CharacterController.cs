using Enviroment;
using Stats;
using UnityEngine;

namespace Characters
{
    public abstract class CharacterController : DestroyableController
    {
        protected virtual void Awake()
        {
            health = GetBasicStats().GetMaxHp();
        }

        public abstract BasicStatsBlock GetBasicStats();
        public abstract void OnWeaponDestroy();

        public abstract Vector3 WeaponPivot();

        public virtual void OnHit()
        {
        }
    }
}