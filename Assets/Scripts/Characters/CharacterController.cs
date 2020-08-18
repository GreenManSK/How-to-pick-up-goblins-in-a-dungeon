using Enviroment;
using Stats;
using UnityEngine;

namespace Characters
{
    public abstract class CharacterController : DestroyableController
    {
        protected virtual void Awake()
        {
            health = 5 * GetBasicStats().con;
        }

        public abstract BasicStatsBlock GetBasicStats();
        public abstract void OnWeaponDestroy();
        public abstract bool IsFlipped();

        public abstract Vector3 WeaponPivot();

        public virtual void OnHit()
        {
        }
    }
}