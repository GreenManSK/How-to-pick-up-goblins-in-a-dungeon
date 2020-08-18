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

        public EnemyStatsBlock statsBlock;
        public GameObject weapon;
        public Vector3 weaponPivot = Vector3.zero;
        public float maxSpeed = 2f;
        public FemaleAvatarData avatarData;

        public float resistance;

        public GameObject hearths;
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
            ChangeResistance(statsBlock.GetMaxResistance(), false);
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
            }
            else if (_state == EnemyState.Moving && _aiPath.desiredVelocity == Vector3.zero)
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
            if (state != EnemyState.Moving)
                animator.SetTrigger(StopAnimation);
            switch (state)
            {
                case EnemyState.Idle:
                    break;
                case EnemyState.Attacking:
                    ToggleMove(false);
                    break;
                case EnemyState.Dead:
                    ToggleMove(false);
                    _onDestroyCallback?.Invoke();
                    break;
                case EnemyState.Seduced:
                    Instantiate(hearths, transform);
                    ToggleMove(false);
                    _onDestroyCallback?.Invoke();
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

        private void ToggleMove(bool enable)
        {
            _aiPath.maxSpeed = enable ? maxSpeed : 0;
        }

        public void ChangeResistance(float value, bool relative = true)
        {
            if (_state == EnemyState.Seduced || _state == EnemyState.Dead)
                return;

            resistance = relative ? resistance + value : value;
            resistance = Mathf.Max(resistance, 0f);
            var progress = resistance / statsBlock.GetMaxResistance();
            if (progress < .333f)
                avatarData.blush = Blush.Large;
            else if (progress < .666f)
                avatarData.blush = Blush.Small;
            else
                avatarData.blush = Blush.None;
            if (Mathf.Approximately(resistance, 0))
            {
                ChangeState(EnemyState.Seduced);
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
            if (_state == EnemyState.Dead || _state == EnemyState.Seduced)
                return;
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
    }
}