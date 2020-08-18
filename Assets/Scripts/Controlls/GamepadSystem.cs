using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

namespace Controlls
{
    public class GamepadSystem : MonoBehaviour
    {
        private static GamepadSystem _instance;

        public static GamepadSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    Init();
                }

                return _instance;
            }
        }

        public static void Init()
        {
            if (_instance != null) return;
            var obj = new GameObject {name = "GamepadSystem"};
            _instance = obj.AddComponent<GamepadSystem>();
            DontDestroyOnLoad(obj);
        }

        private float _leftMotor = 0f;
        private float _rightMotor = 0f;
        private Color _lightColor = Color.clear;

        public void AddVibration(float left, float right, float timeInS)
        {
            if (!GamepadExists())
                return;
            StartCoroutine(UpdateVibration(left, right, timeInS));
        }

        public void SetColor(Color color)
        {
            if (!GamepadExists())
                return;
            if (Gamepad.current is DualShockGamepad)
            {
                Debug.Log($"hi {color}");
                var dualshock = Gamepad.current as DualShockGamepad;
                dualshock.SetLightBarColor(color);
                _lightColor = color;
            }
        }

        public void SetColor(Color color, float timeInS)
        {
            StartCoroutine(UpdateColor(color, timeInS));
        }

        private IEnumerator UpdateColor(Color color, float timeInS)
        {
            SetColor(color);
            yield return new WaitForSeconds(timeInS);
            if (color == _lightColor)
            {
                SetColor(Color.clear);
            }
        }

        private IEnumerator UpdateVibration(float left, float right, float timeInS)
        {
            _leftMotor += left;
            _rightMotor += right;
            Gamepad.current.SetMotorSpeeds(_leftMotor, _rightMotor);
            yield return new WaitForSeconds(timeInS);
            _leftMotor -= left;
            _rightMotor -= right;
            Gamepad.current.SetMotorSpeeds(_leftMotor, _rightMotor);
        }

        private bool GamepadExists()
        {
            return Gamepad.current != null;
        }
    }
}