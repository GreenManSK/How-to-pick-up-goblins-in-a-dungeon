using UnityEngine;

namespace Characters.Enemy
{
    public class DatingEnemyBehaviour : AEnemyBehaviour
    {
        public override void OnTransitionIn(EnemyController context)
        {
            base.OnTransitionIn(context);
            Context.ToggleMove(false);
            Context.animator.SetTrigger(EnemyController.StopAnimation);
        }

        public override void OnSetTarget(Transform target)
        {
            if (target != null)
            {
                Context.ToggleMove(true);
                Context.Target = target;
                Context.ChangeState(EnemyState.Idle);
            }
        }

        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Dating;
        }
    }
}