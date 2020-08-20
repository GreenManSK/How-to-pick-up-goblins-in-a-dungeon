using UnityEngine;
using UnityEngine.UI;

namespace Dating
{
    public class SeductionButtonController : MonoBehaviour
    {
        public SeductionType type = SeductionType.Compliment;
        public Button Button { get; private set; }

        private void Awake()
        {
            Button = GetComponent<Button>();
        }
    }
}