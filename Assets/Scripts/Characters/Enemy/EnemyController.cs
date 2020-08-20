using System;
using System.Collections.Generic;
using Constants;
using Dating;
using Dating.Avatar.FemaleBody;
using Pathfinding;
using Services;
using Services.Events;
using Stats;
using UnityEngine;

namespace Characters.Enemy
{
    public enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
        Seduced,
        Dead,
        Dating
    }

    [Serializable]
    public class EnemyData
    {
        public EnemyStatsBlock statsBlock;
        public GameObject weapon;
        public Vector3 weaponPivot = Vector3.zero;
        public float maxSpeed = 2f;
        public FemaleAvatarData avatarData;
        public float resistance;
    }

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(AIDestinationSetter))]
    public class EnemyController : CharacterController
    {
        public static readonly int StopAnimation = Animator.StringToHash("Idle");
        public static readonly int MoveAnimation = Animator.StringToHash("Move");

        public delegate void OnSetInactiveCallback();

        public EnemyData data;

        public GameObject hearths;
        public SpriteRenderer sprite;
        public Animator animator;
        public Rigidbody2D rigidbody2d;

        public WeaponController weapon;
        public OnSetInactiveCallback onSetInactiveCallback;
        public Vector3 DesiredVelocity => _aiPath.desiredVelocity;
        public float RemainingDistance => _aiPath.remainingDistance;
        public Vector3 Destination => _aiPath.destination;

        public Transform Target
        {
            set => _aiDestinationSetter.target = value;
        }

        private AIPath _aiPath;
        private AIDestinationSetter _aiDestinationSetter;
        private IEnemyBehaviour _behaviour;

        private readonly Dictionary<EnemyState, IEnemyBehaviour> _behaviours = new Dictionary<EnemyState, IEnemyBehaviour>();

        private void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            _aiPath = GetComponent<AIPath>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            data.avatarData = FemaleAvatarData.Random();
            ChangeState(EnemyState.Idle);
            ChangeResistance(data.statsBlock.GetMaxResistance());
        }

        private void Update()
        {
            _behaviour.OnUpdate();
        }

        public void ChangeState(EnemyState state)
        {
            if (_behaviour != null && _behaviour.IsState(state))
            {
                return;
            }

            _behaviour?.OnTransitionOut();
            if (!_behaviours.ContainsKey(state))
            {
                switch (state)
                {
                    case EnemyState.Idle:
                        _behaviours.Add(state, new IdleEnemyBehaviour());
                        break;
                    case EnemyState.Moving:
                        _behaviours.Add(state, new MovingEnemyBehaviour());
                        break;
                    case EnemyState.Attacking:
                        _behaviours.Add(state,new AttackingEnemyBehaviour());
                        break;
                    case EnemyState.Seduced:
                        _behaviours.Add(state, new SeducedEnemyBehaviour());
                        break;
                    case EnemyState.Dead:
                        _behaviours.Add(state, new DeadEnemyBehaviour());
                        break;
                    case EnemyState.Dating:
                        _behaviours.Add(state, new DatingEnemyBehaviour());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }

            _behaviour = _behaviours[state];

            _behaviour.OnTransitionIn(this);
        }

        public void Seduce(float value, SeductionType type)
        {
            // TODO: Add type effectivnes
            ChangeResistance(data.resistance - value);
        } 

        private void ChangeResistance(float value)
        {
            if (_behaviour.IsState(EnemyState.Dead))
                return;

            data.resistance = Mathf.Max(value, 0f);

            UpdateBlush();

            if (Mathf.Approximately(data.resistance, 0))
            {
                ChangeState(EnemyState.Seduced);
            }
        }

        public void SetTarget(Transform target, OnSetInactiveCallback onSetInactiveCallback = null)
        {
            if (onSetInactiveCallback != null)
                this.onSetInactiveCallback = onSetInactiveCallback;
            _behaviour.OnSetTarget(target);
        }

        protected override void OnDeath()
        {
            ChangeState(EnemyState.Dead);
            base.OnDeath();
        }

        public void ToggleMove(bool enable)
        {
            _aiPath.maxSpeed = enable ? data.maxSpeed : 0;
        }

        private void UpdateBlush()
        {
            var progress = data.resistance / data.statsBlock.GetMaxResistance();
            if (progress < .333f)
                data.avatarData.blush = Blush.Large;
            else if (progress < .666f)
                data.avatarData.blush = Blush.Small;
            else
                data.avatarData.blush = Blush.None;
        }

        public override BasicStatsBlock GetBasicStats()
        {
            return data.statsBlock;
        }

        public override void OnWeaponDestroy()
        {
            weapon = null;
            if (_behaviour.IsState(EnemyState.Attacking))
                ChangeState(EnemyState.Moving);
        }

        public override Vector3 WeaponPivot()
        {
            return data.weaponPivot;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_behaviour.IsState(EnemyState.Seduced))
                return;
            if (other.gameObject.CompareTag(Tags.Player))
            {
                EventSystem.Send(new SeducedPickUpEvent(data.statsBlock.resistance));
                Destroy(gameObject);
            }
        }
    }
}