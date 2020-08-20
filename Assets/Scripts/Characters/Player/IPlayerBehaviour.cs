using UnityEngine;

namespace Characters.Player
{
    public interface IPlayerBehaviour
    {
        void OnTransitionIn(PlayerController context);
        void OnTransitionOut();
        void OnUpdate();
        void OnFixedUpdate();
        bool IsState(PlayerState state);
    }

    public abstract class APlayerBehaviour : IPlayerBehaviour
    {
        protected PlayerController Player;

        public virtual void OnTransitionIn(PlayerController context)
        {
            Player = context;
        }

        public virtual void OnTransitionOut()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public abstract bool IsState(PlayerState state);
    }

    public class IdlePlayerBehaviour : APlayerBehaviour
    {
        public override void OnTransitionIn(PlayerController context)
        {
            base.OnTransitionIn(context);
            if (Player.weapon != null)
            {
                Player.ChangeState(PlayerState.Attacking);
                return;
            }

            if (Player.Movement != Vector2.zero)
            {
                Player.ChangeState(PlayerState.Moving);
                return;
            }

            context.Animator.SetTrigger(PlayerController.StopAnimation);
        }

        public override bool IsState(PlayerState state)
        {
            return state == PlayerState.Idle;
        }
    }

    public class MovingPlayerBehaviour : APlayerBehaviour
    {
        public override void OnTransitionIn(PlayerController context)
        {
            base.OnTransitionIn(context);
            context.Animator.SetTrigger(PlayerController.MoveAnimation);
        }

        public override void OnUpdate()
        {
            Player.FixFlip();
        }

        public override void OnFixedUpdate()
        {
            var change = Player.moveSpeed * Time.fixedDeltaTime * Player.Movement;
            Player.Rigidbody2D.MovePosition(Player.Rigidbody2D.position + change);
        }

        public override bool IsState(PlayerState state)
        {
            return state == PlayerState.Moving;
        }
    }

    public class AttackingPlayerBehaviour : APlayerBehaviour
    {
        public override void OnTransitionIn(PlayerController context)
        {
            base.OnTransitionIn(context);
            context.Animator.SetTrigger(PlayerController.StopAnimation);
            Attack();
        }

        public override void OnTransitionOut()
        {
            if (Player.weapon != null)
            {
                Player.weapon.ToggleWeapon(false);
            }
        }

        private void Attack()
        {
            if (Player.weapon == null)
            {
                var weaponObject = Object.Instantiate(Player.weaponPrefab, Player.transform);
                Player.weapon = weaponObject.GetComponent<WeaponController>();
                Player.weapon.SetData(Player, Player.Direction);
            }
            else
            {
                Player.weapon.ToggleWeapon(true);
            }
        }

        public override bool IsState(PlayerState state)
        {
            return state == PlayerState.Attacking;
        }
    }

    public class DatingPlayerBehaviour : APlayerBehaviour
    {
        public override void OnTransitionIn(PlayerController context)
        {
            base.OnTransitionIn(context);
            context.Animator.SetTrigger(PlayerController.StopAnimation);
        }

        public override bool IsState(PlayerState state)
        {
            return state == PlayerState.Dating;
        }
    }
}