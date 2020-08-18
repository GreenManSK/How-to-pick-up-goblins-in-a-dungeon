using Dating.Avatar.FemaleBody;
using Pathfinding;
using Stats;
using UnityEngine;

namespace Characters
{
    public enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
        Seduced,
        Dead
    }

    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(AIDestinationSetter))]
    public class EnemyController : CharacterController
    {
        private static readonly int StopAnimation = Animator.StringToHash("Idle");
        private static readonly int MoveAnimation = Animator.StringToHash("Move");

        public delegate void OnDestroyCallback();

        public GirlStatsBlock statsBlock;
        public GameObject weapon;
        public Vector3 weaponPivot = Vector3.zero;
        public float maxSpeed = 2f;
        public FemaleAvatarData avatarData;

        public SpriteRenderer sprite;
        public Animator animator;

        private AIPath _aiPath;
        private AIDestinationSetter _aiDestinationSetter;
        private EnemyState _state = EnemyState.Idle;

        private OnDestroyCallback _onDestroyCallback;

        private void Start()
        {
            _aiPath = GetComponent<AIPath>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            avatarData = FemaleAvatarData.Random();
        }

        private void Update()
        {
            if (_aiDestinationSetter.target == null)
                return;

            if (_aiPath.remainingDistance <= 1f && _state == EnemyState.Moving)
            {
                Attack();
            }

            if (_state == EnemyState.Idle && _aiPath.desiredVelocity != Vector3.zero)
            {
                ChangeState(EnemyState.Moving);
            } else if (_state == EnemyState.Moving && _aiPath.desiredVelocity == Vector3.zero)
            {
                ChangeState(EnemyState.Idle);
            }

            if (_state == EnemyState.Moving)
            {
                FlipSprite();
            }
        }

        private void ChangeState(EnemyState state)
        {
            switch (state)
            {
                case EnemyState.Idle:
                    animator.SetTrigger(StopAnimation);
                    break;
                case EnemyState.Attacking:
                case EnemyState.Seduced:
                case EnemyState.Dead:
                    animator.SetTrigger(StopAnimation);
                    ToggleMove(false);
                    break;
                case EnemyState.Moving:
                    animator.SetTrigger(MoveAnimation);
                    ToggleMove(true);
                    break;
            }

            _state = state;
        }

        protected override void OnDeath()
        {
            ChangeState(EnemyState.Dead);
            _onDestroyCallback?.Invoke();
            base.OnDeath();
        }

        private void Attack()
        {
            ChangeState(EnemyState.Attacking);
            var weaponObject = Instantiate(weapon, transform);
            var direction = _aiPath.destination - transform.position;
            weaponObject.GetComponent<WeaponController>().SetData(this, direction);
        }

        private void FlipSprite()
        {
            if (!Mathf.Approximately(_aiPath.desiredVelocity.x, 0))
            {
                sprite.flipX = _aiPath.desiredVelocity.x < 0;
            }
        }

        public override BasicStatsBlock GetBasicStats()
        {
            return statsBlock;
        }

        public override void OnWeaponDestroy()
        {
            ChangeState(EnemyState.Moving);
        }

        public override bool IsFlipped()
        {
            return sprite.flipX;
        }

        public override Vector3 WeaponPivot()
        {
            return weaponPivot;
        }

        public void SetTarget(Transform target, OnDestroyCallback onDestroyCallback = null)
        {
            _aiDestinationSetter.target = target;
            if (onDestroyCallback != null)
                _onDestroyCallback = onDestroyCallback;
            if (target == null)
            {
                ToggleMove(false);
                if (_state == EnemyState.Moving || _state == EnemyState.Attacking)
                {
                    ChangeState(EnemyState.Idle);
                }
            }
            else
            {
                ToggleMove(true);
            }
        }

        private void ToggleMove(bool enable)
        {
            _aiPath.maxSpeed = enable ? maxSpeed : 0;
        }
    }
}