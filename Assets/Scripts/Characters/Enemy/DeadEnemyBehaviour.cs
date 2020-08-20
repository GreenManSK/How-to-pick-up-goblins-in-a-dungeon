using Constants;
using Services;
using Services.Events;

namespace Characters.Enemy
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
        }
        
        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Dead;
        }
    }
}