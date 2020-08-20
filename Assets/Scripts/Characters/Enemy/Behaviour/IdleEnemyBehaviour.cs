using UnityEngine;

namespace Characters.Enemy.Behaviour
{
    public class IdleEnemyBehaviour : AEnemyBehaviour
    {
        public override void OnTransitionIn(EnemyController context)
        {
            base.OnTransitionIn(context);
            Context.animator.SetTrigger(EnemyController.StopAnimation);
        }

        public override void OnUpdate()
        {
            if (Context.weapon != null)
            {
                Context.ChangeState(EnemyState.Attacking);
                return;
            }
            if (Context.DesiredVelocity != Vector3.zero)
            {
                Context.ChangeState(EnemyState.Moving);
            }
        }

        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Idle;
        }

        public override void OnSetTarget(Transform target)
        {
            if (target == null)
            {
                Context.ChangeState(EnemyState.Dating);
            }
            else
            {
                Context.Target = target;
            }
        }
    }
}