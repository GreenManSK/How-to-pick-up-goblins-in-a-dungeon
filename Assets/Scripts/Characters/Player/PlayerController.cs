using System;
using System.Collections.Generic;
using Controlls;
using Stats;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : CharacterController
    {
        public static readonly int StopAnimation = Animator.StringToHash("Stop");
        public static readonly int MoveAnimation = Animator.StringToHash("Move");

        public PlayerStatsBlock statsBlock;
        public float moveSpeed = 5f;
        public GameObject weaponPrefab;
        public Vector3 weaponPivot = Vector3.zero;

        public SpriteRenderer sprite;
        public Animator Animator => _animator;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Vector2 Movement { get; private set; } = Vector2.zero;
        public Vector2 Direction { get; private set; } = Vector2.zero;
        public WeaponController weapon;

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private IPlayerBehaviour _behaviour;

        private readonly Dictionary<PlayerState, IPlayerBehaviour> _behaviours =
            new Dictionary<PlayerState, IPlayerBehaviour>();


        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            ChangeState(PlayerState.Idle);
        }

        protected override void Awake()
        {
            base.Awake();
            var input = GameController.Input;

            input.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
            input.Player.Move.canceled += ctx => Stop();

            input.Player.Attack.performed += ctx => Attack();
        }

        private void OnEnable()
        {
            GameController.Input.Player.Enable();
        }

        private void OnDisable()
        {
            GameController.Input.Player.Disable();
        }

        private void Update()
        {
            _behaviour.OnUpdate();
        }

        private void FixedUpdate()
        {
            _behaviour.OnFixedUpdate();
        }

        public void ChangeState(PlayerState state)
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
                    case PlayerState.Idle:
                        _behaviours.Add(state, new IdlePlayerBehaviour());
                        break;
                    case PlayerState.Moving:
                        _behaviours.Add(state, new MovingPlayerBehaviour());
                        break;
                    case PlayerState.Attacking:
                        _behaviours.Add(state, new AttackingPlayerBehaviour());
                        break;
                    case PlayerState.Dating:
                        _behaviours.Add(state, new DatingPlayerBehaviour());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }

            _behaviour = _behaviours[state];

            _behaviour.OnTransitionIn(this);
        }

        private void Move(Vector2 move)
        {
            Movement = Direction = move;
            if (_behaviour.IsState(PlayerState.Idle))
            {
                ChangeState(PlayerState.Moving);
            }
        }

        private void Stop()
        {
            Movement = Vector2.zero;
            if (_behaviour.IsState(PlayerState.Moving))
            {
                ChangeState(PlayerState.Idle);
            }
        }

        private void Attack()
        {
            if (_behaviour.IsState(PlayerState.Idle) || _behaviour.IsState(PlayerState.Moving))
            {
                ChangeState(PlayerState.Attacking);
            }
        }

        public void FixFlip()
        {
            if (!Mathf.Approximately(Movement.x, 0))
            {
                sprite.flipX = Movement.x < 0;
            }
        }
        
        public override void OnWeaponDestroy()
        {
            weapon = null;
            if (_behaviour.IsState(PlayerState.Attacking))
                ChangeState(PlayerState.Idle);
        }

        public override BasicStatsBlock GetBasicStats()
        {
            return statsBlock;
        }

        public override Vector3 WeaponPivot()
        {
            return weaponPivot;
        }

        public override void Damage(float value)
        {
            base.Damage(value);
            if (Gamepad.current == null)
                return;
            GamepadSystem.Instance.AddVibration(1f, 1f, 0.5f);
            GamepadSystem.Instance.SetColor(Color.red, .5f);
        }

        public override void OnHit()
        {
            base.OnHit();
            GamepadSystem.Instance.AddVibration(0.5f, 0.5f, 0.2f);
        }

        public void TogglePlayMode(bool isDating)
        {
            ChangeState(isDating ? PlayerState.Dating : PlayerState.Idle);
        }
    }
}