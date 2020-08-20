using System.Collections.Generic;
using System.Linq;
using Characters.Enemy;
using Characters.Player;
using Cinemachine;
using Dating.Avatar.FemaleBody;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dating
{
    public class DatingController : MonoBehaviour
    {
        public GameObject datingUi;
        public FemaleAvatarController avatarController;
        public GameObject dateArrow;
        public CinemachineVirtualCamera mainVirtualCamera;

        public PlayerController player;
        public GameObject buttonsContainer;
        public SeductionButtonController[] buttons = new SeductionButtonController[0];

        private List<EnemyController> _enemies = new List<EnemyController>();
        private int _activeIndex = 0;
        private bool _isDating = false;
        private bool _isSelected = false;
        private int _buttonIndex = 0;

        private void Start()
        {
            GameController.Input.Dating.DateButton.performed += ctx => OnDateButton();
            GameController.Input.Dating.Next.performed += ctx => OnNext();
            GameController.Input.Dating.Prev.performed += ctx => OnPrev();
            GameController.Input.Dating.Select.performed += ctx => OnSelect();
            GameController.Input.Dating.Exit.performed += ctx => ToggleDating(false);

            ToggleDating(false);
        }

        private void OnEnable()
        {
            GameController.Input.Dating.Enable();
        }

        private void OnDisable()
        {
            GameController.Input.Dating.Disable();
        }

        private void OnDateButton()
        {
            if (!_isDating)
            {
                ToggleDating(true);
            }
            else if (_isSelected)
            {
                Deselect();
            }
            else
            {
                ToggleDating(false);
            }
        }

        private void OnNext()
        {
            if (_isSelected)
            {
                _buttonIndex += 1;
                _buttonIndex %= buttons.Length;
                MarkButton();
            }
            else
            {
                MarkNext();
            }
        }

        private void OnPrev()
        {
            if (_isSelected)
            {
                _buttonIndex -= 1;
                _buttonIndex += buttons.Length;
                _buttonIndex %= buttons.Length;
                MarkButton();
            }
            else
            {
                MarkPrev();
            }
        }
        
        private void OnSelect()
        {
            if (_isSelected)
            {
                Seduce();
            }
            else
            {
                _isSelected = true;
                _buttonIndex = 0;
                buttonsContainer.SetActive(true);
                MarkButton();
            }
        }

        public void ToggleDating(bool? isDating = null)
        {
            _isDating = isDating ?? !_isDating;
            SetData();
            if (!_enemies.Any())
                _isDating = false;
            dateArrow.SetActive(_isDating);
            datingUi.SetActive(_isDating);
            player.TogglePlayMode(_isDating);
            if (!_isDating)
            {
                mainVirtualCamera.Follow = mainVirtualCamera.LookAt = player.transform;
            }

            foreach (var enemy in _enemies)
            {
                enemy.SetTarget(_isDating ? null : player.transform);
            }

            _isSelected = false;
            buttonsContainer.SetActive(false);
        }

        private void MarkButton()
        {
            buttons[_buttonIndex].Button.Select();
        }
        
        private void MarkNext()
        {
            if (!_isDating || _isSelected)
                return;
            _activeIndex += 1;
            if (_activeIndex >= _enemies.Count)
                _activeIndex = 0;
            MarkEnemy(_activeIndex);
        }

        private void MarkPrev()
        {
            if (!_isDating || _isSelected)
                return;
            _activeIndex -= 1;
            if (_activeIndex < 0)
                _activeIndex = _enemies.Count - 1;
            MarkEnemy(_activeIndex);
        }

        private void MarkEnemy(int activeIndex)
        {
            var enemy = _enemies[activeIndex];
            var enemyTransform = enemy.transform;
            mainVirtualCamera.Follow = mainVirtualCamera.LookAt = enemyTransform;
            dateArrow.transform.position = enemyTransform.position + new Vector3(0, 0.5f, 0);
            avatarController.SetData(enemy.data.avatarData);
        }

        private void Deselect()
        {
            _isSelected = false;
            buttonsContainer.SetActive(false);
        }

        private void Seduce()
        {
            if (!_isDating)
                return;
            var enemy = _enemies[_activeIndex];
            enemy.Seduce(player.statsBlock.cha, buttons[_buttonIndex].type);
            avatarController.Redraw();
        }

        private void SetData()
        {
            if (!_isDating)
                return;
            var enemies = GameController.Instance.enemies;

            _activeIndex = 0;
            _enemies.Clear();

            _enemies.AddRange(enemies);
            _enemies.Sort((a, b) =>
            {
                var aPos = a.transform.position;
                var bPos = b.transform.position;
                return Mathf.Approximately(aPos.x, bPos.x) ? aPos.y.CompareTo(bPos.y) : aPos.x.CompareTo(bPos.x);
            });

            if (_enemies.Any())
            {
                MarkEnemy(_activeIndex);
            }
        }
    }
}