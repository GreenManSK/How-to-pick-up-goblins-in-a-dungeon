using UnityEngine;

namespace Characters.Enemy.Behaviour
{
    public class AttackingEnemyBehaviour : AEnemyBehaviour
    {
        public override void OnTransitionIn(EnemyController context)
        {
            base.OnTransitionIn(context);
            Context.animator.SetTrigger(EnemyController.StopAnimation);
            Attack();
        }

        public override void OnTransitionOut()
        {
            Context.ToggleMove(true);
            
        }

        private void Attack()
        {
            Context.ToggleMove(false);
            if (Context.weapon == null)
            {
                var weaponObject = Object.Instantiate(Context.data.weapon, Context.transform);
                var direction = Context.Destination - Context.transform.position;
                Context.weapon = weaponObject.GetComponent<WeaponController>();
                Context.weapon.SetData(Context, direction);
            }
            else
            {
                Context.weapon.ToggleWeapon(true);
            }
        }

        public override bool IsState(EnemyState state)
        {
            return state == EnemyState.Attacking;
        }

        public override void OnSetTarget(Transform target)
        {
            if (target == null)
            {
                Context.weapon.ToggleWeapon(false);
                Context.ChangeState(EnemyState.Dating);
            }
        }
    }
}