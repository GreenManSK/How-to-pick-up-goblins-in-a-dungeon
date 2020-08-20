using Constants;
using Services;
using Services.Events;
using UnityEngine;

namespace Characters.Enemy.Behaviour
{
    public class SeducedEnemyBehaviour : AEnemyBehaviour
    {
        public override void OnTransitionIn(EnemyController context)
        {
            base.OnTransitionIn(context);
            
            Context.animator.SetTrigger(EnemyController.StopAnimation);
            Context.rigidbody2d.isKinematic = true;
            Context.gameObject.layer = Layers.Walls;
            
            Context.onSetInactiveCallback?.Invoke();
            
            Object.Instantiate(Context.hearths, Context.transform);
            
            DestroyWeapon();
            EventSystem.Send(SeductionEvent.Instance);
        }

        private void DestroyWeapon()
        {
            if (Context.weapon == null) return;
            Object.Destroy(Context.weapon.gameObject);
            Context.OnWeaponDestroy();
        }

        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Seduced;
        }
    }
}