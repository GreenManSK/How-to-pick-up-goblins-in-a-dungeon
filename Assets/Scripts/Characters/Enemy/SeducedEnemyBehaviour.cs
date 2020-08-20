using Constants;
using UnityEngine;

namespace Characters.Enemy
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