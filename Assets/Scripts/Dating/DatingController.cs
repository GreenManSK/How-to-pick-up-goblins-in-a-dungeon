using System;
using System.Collections.Generic;
using System.Linq;
using Characters;
using Dating.Avatar.FemaleBody;
using UnityEngine;

namespace Dating
{
    public class DatingController : MonoBehaviour
    {
        public GameObject datingUi;
        public FemaleAvatarController avatarController;
        public GameObject dateArrow;

        public PlayerController playerController;

        private List<EnemyController> _enemies = new List<EnemyController>();
        private int _activeIndex = 0;

        private void Start()
        {
            GameController.Input.Dating.Next.performed += ctx => SelectNext();
            GameController.Input.Dating.Prev.performed += ctx => SelectPrev();
            GameController.Input.Dating.Select.performed += ctx => Seduce();
        }

        private void OnEnable()
        {
            datingUi.SetActive(true);
        }

        private void OnDisable()
        {
            datingUi.SetActive(false);
        }

        private void SelectNext()
        {
            if (!gameObject.activeSelf)
                return;
            _activeIndex += 1;
            if (_activeIndex >= _enemies.Count)
                _activeIndex = 0;
            SelectEnemy(_activeIndex);
        }

        private void SelectPrev()
        {
            if (!gameObject.activeSelf)
                return;
            _activeIndex -= 1;
            if (_activeIndex < 0)
                _activeIndex = _enemies.Count - 1;
            SelectEnemy(_activeIndex);
        }

        private void SelectEnemy(int activeIndex)
        {
            var enemy = _enemies[activeIndex];
            dateArrow.transform.position = enemy.transform.position + new Vector3(0,0.5f,0);
            avatarController.SetData(enemy.avatarData);
        }

        private void Seduce()
        {
            if (!gameObject.activeSelf)
                return;
            var enemy = _enemies[_activeIndex];
            enemy.ChangeResistance(-1 * playerController.statsBlock.cha);
            avatarController.Redraw();
        }

        public void SetData(IEnumerable<EnemyController> enemies)
        {
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
                dateArrow?.SetActive(true);
                SelectEnemy(_activeIndex);
            }
            else
            {
                dateArrow?.SetActive(false);
            }
        }
    }
}