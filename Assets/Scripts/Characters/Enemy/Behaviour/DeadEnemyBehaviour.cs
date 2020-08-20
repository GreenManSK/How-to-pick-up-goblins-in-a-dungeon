using Constants;
using Services;
using Services.Events;
using UnityEngine;

namespace Characters.Enemy.Behaviour
{
    public class DeadEnemyBehaviour : AEnemyBehaviour
    {
        public override void OnTransitionIn(EnemyController context)
        {
            base.OnTransitionIn(context);
            Context.animator.SetTrigger(EnemyController.StopAnimation);
            Context.rigidbody2d.isKinematic = true;
            Context.gameObject.layer = Layers.Walls;
            Context.onSetInactiveCallback?.Invoke();
            EventSystem.Send(new KillEvent(Context.data.statsBlock.con));
            Object.Destroy(context.gameObject);
        }
        
        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Dead;
        }
    }
}