using Controlls;
using Stats;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : CharacterController
    {
        private static readonly int StopAnimation = Animator.StringToHash("Stop");
        private static readonly int MoveAnimation = Animator.StringToHash("Move");

        public float moveSpeed = 5f;
        public SpriteRenderer sprite;
        public GameObject weapon;
        public PlayerStatsBlock statsBlock;
        public Vector3 weaponPivot = Vector3.zero;

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private Vector2 _movement = Vector2.zero;
        private Vector2 _direction = Vector2.zero;
        private bool _isAttacking = false;
        private bool _isDating = false;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
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

        private void FixedUpdate()
        {
            if (_isAttacking || _isDating)
                return;
            _rigidbody2D.MovePosition(_rigidbody2D.position + moveSpeed * Time.fixedDeltaTime * _movement);
        }

        private void Move(Vector2 move)
        {
            if (!_isAttacking && !_isDating)
            {
                _animator.SetTrigger(MoveAnimation);
                if (move.x != 0)
                {
                    sprite.flipX = move.x < 0;
                }
            }

            _movement = _direction = move;
        }

        private void Stop()
        {
            _animator.SetTrigger(StopAnimation);
            _movement = Vector2.zero;
        }

        private void Attack()
        {
            if (_isDating)
                return;

            if (_isAttacking)
                return;
            _animator.SetTrigger(StopAnimation);
            var weaponObject = Instantiate(weapon, transform);
            weaponObject.GetComponent<WeaponController>().SetData(this, _direction);
            _isAttacking = true;
        }

        public override void OnWeaponDestroy()
        {
            if (_movement.x != 0)
            {
                sprite.flipX = _movement.x < 0;
            }

            _isAttacking = false;
        }

        public override bool IsFlipped()
        {
            return sprite.flipX;
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
            if (isDating)
            {
                _isDating = true;
                _animator.SetTrigger(StopAnimation);
            }
            else
            {
                _isDating = false;
                if (_movement != Vector2.zero)
                    Move(_movement);
            }
        }
    }
}