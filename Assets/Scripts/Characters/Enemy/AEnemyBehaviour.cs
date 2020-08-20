using UnityEngine;

namespace Characters.Enemy
{
    public abstract class AEnemyBehaviour : IEnemyBehaviour
    {
        protected EnemyController Context;

        public virtual void OnTransitionIn(EnemyController context)
        {
            Context = context;
        }
        
        public virtual void OnTransitionOut() {}

        public virtual void OnUpdate()
        {
        }

        public abstract bool IsState(EnemyState state);

        public virtual void OnSetTarget(Transform target)
        {
        }
    }
}