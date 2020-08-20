using UnityEngine;
using CharacterController = Characters.CharacterController;

namespace Enviroment
{
    public class DestroyableController : MonoBehaviour
    {
        public float health = 1;

        public virtual void Damage(float value, CharacterController attacker)
        {
            health -= value;
            if (Mathf.Approximately(health, 0f) || health <= 0)
            {
                OnDeath();
            }
        }

        protected virtual void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}