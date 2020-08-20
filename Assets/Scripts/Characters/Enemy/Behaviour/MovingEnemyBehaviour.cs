using UnityEngine;

namespace Characters.Enemy.Behaviour
{
    public class MovingEnemyBehaviour : AEnemyBehaviour
    {
        public override void OnTransitionIn(EnemyController context)
        {
            base.OnTransitionIn(context);
            Context.animator.SetTrigger(EnemyController.MoveAnimation);
        }

        public override void OnUpdate()
        {
            if (Context.RemainingDistance <= 1f)
            {
                Context.ChangeState(EnemyState.Attacking);
                return;
            }

            if (Context.DesiredVelocity == Vector3.zero)
            {
                Context.ChangeState(EnemyState.Idle);
                return;
            }

            FlipSprite();
        }

        private void FlipSprite()
        {
            if (!Mathf.Approximately(Context.DesiredVelocity.x, 0))
            {
                Context.sprite.flipX = Context.DesiredVelocity.x < 0;
            }
        }
        
        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Moving;
        }

        public override void OnSetTarget(Transform target)
        {
            Context.ChangeState(EnemyState.Dating);
        }
    }
}