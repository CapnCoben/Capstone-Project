//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Sample CControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @SampleCControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SampleCControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Sample CControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""887f3a9b-ff7f-44a9-b62f-8c7c67ebbe25"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6aa8271d-9ede-4811-9574-a664b1829c04"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""16e468d5-9051-415d-a4cd-2e8dc2b02eec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""242ca311-0084-4420-95ad-78dceb213d28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3a92669-b3dd-4113-9b3b-8f5b13ba156c"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/stick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2e2e897a-7f57-4b2b-9f81-b9e21819c085"",
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
                    ""id"": ""678c59f6-747e-4a51-9dd6-5a8d0963ae2f"",
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
                    ""id"": ""fdb0fc2a-4ac4-442b-9055-c9456ac7a9e2"",
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
                    ""id"": ""01f5f8eb-ad29-44db-bd5f-d5770517fabe"",
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
                    ""id"": ""a112f7d9-c7cb-40a5-b5b4-92c800e586f2"",
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
                    ""id"": ""34283bc0-afe4-4724-81fd-181a5227ddea"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91a9c90b-6aaf-437c-8f8a-ec6a7a7b9825"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88cb10a0-996e-45e5-a2c9-efb983726d41"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""958771bf-f537-4ad0-945c-b3f6a9df65c8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraControls"",
            ""id"": ""2374046c-112c-42da-b53d-7be788e8fb78"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""PassThrough"",
                    ""id"": ""41a1992b-27a9-4d28-a723-338707372f4b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e13406ae-f18e-4907-a767-8076931cf520"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""0f5fb751-f16e-4d1f-bd59-ac8cb276055e"",
            ""actions"": [
                {
                    ""name"": ""Punck"",
                    ""type"": ""Button"",
                    ""id"": ""fc57afd2-e6ab-488d-afcc-cd8ce7c0ac68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""4ec5ce16-2627-453f-bf3d-4c8cfe0144d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""614b06f4-cfc8-4dad-afb0-5c194ab8a4ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d67b1126-f374-475e-a079-04483381d617"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1abda2c-62cb-4325-9493-242ea8731312"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""103090b9-92d2-4fc1-812f-a711f3b0ea2d"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""504488cb-85df-409f-809c-c279dda1f05d"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc7495db-1746-4544-b764-ed7ec93eb5f4"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Run = m_Movement.FindAction("Run", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        // CameraControls
        m_CameraControls = asset.FindActionMap("CameraControls", throwIfNotFound: true);
        m_CameraControls_Newaction = m_CameraControls.FindAction("New action", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Punck = m_Combat.FindAction("Punck", throwIfNotFound: true);
        m_Combat_Kick = m_Combat.FindAction("Kick", throwIfNotFound: true);
        m_Combat_Dodge = m_Combat.FindAction("Dodge", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Run;
    private readonly InputAction m_Movement_Jump;
    public struct MovementActions
    {
        private @SampleCControls m_Wrapper;
        public MovementActions(@SampleCControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Run => m_Wrapper.m_Movement_Run;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // CameraControls
    private readonly InputActionMap m_CameraControls;
    private ICameraControlsActions m_CameraControlsActionsCallbackInterface;
    private readonly InputAction m_CameraControls_Newaction;
    public struct CameraControlsActions
    {
        private @SampleCControls m_Wrapper;
        public CameraControlsActions(@SampleCControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_CameraControls_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_CameraControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICameraControlsActions instance)
        {
            if (m_Wrapper.m_CameraControlsActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_CameraControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public CameraControlsActions @CameraControls => new CameraControlsActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_Punck;
    private readonly InputAction m_Combat_Kick;
    private readonly InputAction m_Combat_Dodge;
    public struct CombatActions
    {
        private @SampleCControls m_Wrapper;
        public CombatActions(@SampleCControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Punck => m_Wrapper.m_Combat_Punck;
        public InputAction @Kick => m_Wrapper.m_Combat_Kick;
        public InputAction @Dodge => m_Wrapper.m_Combat_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @Punck.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnPunck;
                @Punck.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnPunck;
                @Punck.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnPunck;
                @Kick.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnKick;
                @Dodge.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnDodge;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Punck.started += instance.OnPunck;
                @Punck.performed += instance.OnPunck;
                @Punck.canceled += instance.OnPunck;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface ICameraControlsActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnPunck(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
    }
}
