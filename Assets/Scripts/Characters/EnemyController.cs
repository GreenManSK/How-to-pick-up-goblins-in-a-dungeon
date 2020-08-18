using System;
using Dating.Avatar.FemaleBody;
using Pathfinding;
using Stats;
using UnityEngine;

namespace Characters
{
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
        private bool _isMoving;
        private bool _isAttacking = false;

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

            if (_aiPath.remainingDistance <= 1f && !_isAttacking)
            {
                Attack();
            }

            if (!_isAttacking)
            {
                Move();
            }
        }

        private void OnDestroy()
        {
            _onDestroyCallback?.Invoke();
        }

        private void Attack()
        {
            animator.SetTrigger(StopAnimation);
            var weaponObject = Instantiate(weapon, transform);
            var direction = _aiPath.destination - transform.position;
            weaponObject.GetComponent<WeaponController>().SetData(this, direction);
            _isAttacking = true;
        }

        private void Move()
        {
            if (_aiPath.desiredVelocity != Vector3.zero)
            {
                if (!_isMoving)
                {
                    animator.SetTrigger(MoveAnimation);
                }

                if (_aiPath.desiredVelocity.x != 0)
                {
                    sprite.flipX = _aiPath.desiredVelocity.x < 0;
                }

                _isMoving = true;
            }
            else
            {
                if (_isMoving)
                {
                    animator.SetTrigger(StopAnimation);
                }

                _isMoving = false;
            }
        }

        public override BasicStatsBlock GetBasicStats()
        {
            return statsBlock;
        }

        public override void OnWeaponDestroy()
        {
            _isAttacking = false;
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
                maxSpeed = _aiPath.maxSpeed;
                _aiPath.maxSpeed = 0;
                _isMoving = false;
                animator.SetTrigger(StopAnimation);
            }
            else
            {
                _aiPath.maxSpeed = maxSpeed;
            }
        }
    }
}