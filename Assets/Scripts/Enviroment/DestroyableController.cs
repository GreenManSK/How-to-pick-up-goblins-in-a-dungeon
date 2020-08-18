using UnityEngine;

namespace Enviroment
{
    public class DestroyableController : MonoBehaviour
    {
        public float health = 1;

        public virtual void Damage(float value)
        {
            health -= value;
            if (Mathf.Approximately(health, 0f) || health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}