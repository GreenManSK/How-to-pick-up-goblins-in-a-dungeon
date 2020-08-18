// GENERATED AUTOMATICALLY FROM 'Assets/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""260197d0-6054-4769-890b-c9266e19bce7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""24e2d8ac-caff-4d8c-a478-bd078047e9ca"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2e51fa3e-e5a4-48e0-be9d-0a339340d5d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wsad"",
                    ""id"": ""d2214a50-cbe4-411b-864e-9dcc548b42c6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""160566ca-bcbb-40dc-bcab-ea261bd5eeff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""080011e0-8172-4cee-a15e-668e27fea63c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c8357984-ace1-45b8-8a60-1c038d680aa6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0b8a0abd-29be-42ae-af41-2c6bdb413797"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d714f14c-40c4-400f-ad57-abfe4915847c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f54b894b-5f88-431a-bced-e869e163c6b2"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8379e671-5754-4f64-a978-67636ef4cd51"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5ce2784-5b09-4ff4-a6f1-f6b509a6e2d3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dating"",
            ""id"": ""a2f16c3f-bf3b-475a-88d5-7bb40868b350"",
            ""actions"": [
                {
                    ""name"": ""Stop"",
                    ""type"": ""Button"",
                    ""id"": ""0267f5b1-8ee2-49de-a73b-1c028442ea98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""d7f3227b-a1eb-4edd-a1af-8f0169f9cdbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""1f15bf1d-ddb3-4517-ac57-c2d8e8ad0824"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Prev"",
                    ""type"": ""Button"",
                    ""id"": ""644c1722-a2cb-49c5-ab35-2e65f585fc75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""552acd31-22c2-4c7d-803a-3dd4cb2acf2e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d7a9a69-d1ee-4c76-a814-6aba1b6793d3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa4926ff-be47-496d-9c8d-d585b96bdf30"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd22c22e-09e6-49d2-b283-e12132a8ede9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bbc7d4d-372f-4b7f-a262-957de56bc51a"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41818d0a-cf3c-4526-9428-69811de334ee"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Prev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd7446e1-245c-4079-b21e-8421a85ca88c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Prev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8861aa56-f3e2-407e-8fdf-51c526f84156"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Prev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04f49a7e-59a9-4dfe-8cb0-3a64ec24d33c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1771dbc2-697f-4553-820c-3bee59b24e96"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Testing"",
            ""id"": ""888241f9-fc67-4741-a84f-4ade5ead97a5"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""10fa8db9-7ef6-4e6e-ada3-73fc339040f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f871f0f2-b88a-4da4-bdd0-90a68f27b52a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        // Dating
        m_Dating = asset.FindActionMap("Dating", throwIfNotFound: true);
        m_Dating_Stop = m_Dating.FindAction("Stop", throwIfNotFound: true);
        m_Dating_Select = m_Dating.FindAction("Select", throwIfNotFound: true);
        m_Dating_Next = m_Dating.FindAction("Next", throwIfNotFound: true);
        m_Dating_Prev = m_Dating.FindAction("Prev", throwIfNotFound: true);
        // Testing
        m_Testing = asset.FindActionMap("Testing", throwIfNotFound: true);
        m_Testing_Restart = m_Testing.FindAction("Restart", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Attack;
    public struct PlayerActions
    {
        private @Input m_Wrapper;
        public PlayerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Dating
    private readonly InputActionMap m_Dating;
    private IDatingActions m_DatingActionsCallbackInterface;
    private readonly InputAction m_Dating_Stop;
    private readonly InputAction m_Dating_Select;
    private readonly InputAction m_Dating_Next;
    private readonly InputAction m_Dating_Prev;
    public struct DatingActions
    {
        private @Input m_Wrapper;
        public DatingActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Stop => m_Wrapper.m_Dating_Stop;
        public InputAction @Select => m_Wrapper.m_Dating_Select;
        public InputAction @Next => m_Wrapper.m_Dating_Next;
        public InputAction @Prev => m_Wrapper.m_Dating_Prev;
        public InputActionMap Get() { return m_Wrapper.m_Dating; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DatingActions set) { return set.Get(); }
        public void SetCallbacks(IDatingActions instance)
        {
            if (m_Wrapper.m_DatingActionsCallbackInterface != null)
            {
                @Stop.started -= m_Wrapper.m_DatingActionsCallbackInterface.OnStop;
                @Stop.performed -= m_Wrapper.m_DatingActionsCallbackInterface.OnStop;
                @Stop.canceled -= m_Wrapper.m_DatingActionsCallbackInterface.OnStop;
                @Select.started -= m_Wrapper.m_DatingActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_DatingActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_DatingActionsCallbackInterface.OnSelect;
                @Next.started -= m_Wrapper.m_DatingActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_DatingActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_DatingActionsCallbackInterface.OnNext;
                @Prev.started -= m_Wrapper.m_DatingActionsCallbackInterface.OnPrev;
                @Prev.performed -= m_Wrapper.m_DatingActionsCallbackInterface.OnPrev;
                @Prev.canceled -= m_Wrapper.m_DatingActionsCallbackInterface.OnPrev;
            }
            m_Wrapper.m_DatingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Stop.started += instance.OnStop;
                @Stop.performed += instance.OnStop;
                @Stop.canceled += instance.OnStop;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Prev.started += instance.OnPrev;
                @Prev.performed += instance.OnPrev;
                @Prev.canceled += instance.OnPrev;
            }
        }
    }
    public DatingActions @Dating => new DatingActions(this);

    // Testing
    private readonly InputActionMap m_Testing;
    private ITestingActions m_TestingActionsCallbackInterface;
    private readonly InputAction m_Testing_Restart;
    public struct TestingActions
    {
        private @Input m_Wrapper;
        public TestingActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_Testing_Restart;
        public InputActionMap Get() { return m_Wrapper.m_Testing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestingActions set) { return set.Get(); }
        public void SetCallbacks(ITestingActions instance)
        {
            if (m_Wrapper.m_TestingActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_TestingActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_TestingActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_TestingActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_TestingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public TestingActions @Testing => new TestingActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IDatingActions
    {
        void OnStop(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnNext(InputAction.CallbackContext context);
        void OnPrev(InputAction.CallbackContext context);
    }
    public interface ITestingActions
    {
        void OnRestart(InputAction.CallbackContext context);
    }
}
