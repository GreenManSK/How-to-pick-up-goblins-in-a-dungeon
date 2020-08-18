using Characters;
using UnityEngine;

namespace Enviroment
{
    public class RoomController : MonoBehaviour
    {
        public EnemyController[] enemies = new EnemyController[0];

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameController.Instance.AddEnemies(enemies);
            gameObject.SetActive(false);
        }
    }
}