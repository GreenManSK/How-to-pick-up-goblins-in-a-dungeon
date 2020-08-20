using UnityEngine;

namespace Characters.Enemy
{
    public interface IEnemyBehaviour
    {
        void OnTransitionIn(EnemyController context);
        void OnTransitionOut();
        void OnUpdate();
        bool IsState(EnemyState state);
        void OnSetTarget(Transform target);
    }
}