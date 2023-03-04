//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Settings/Input/Controls.inputactions
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

public partial class @PlayerInputControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""40c7c469-ce30-491b-a360-59d6cdd96f71"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""65b256d7-444d-4128-8660-88933aaa0b64"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""be2b9b39-5139-4e8e-add9-9516eb19c49d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jerk"",
                    ""type"": ""Button"",
                    ""id"": ""4cdaf6d1-e48c-4069-8a3d-d5731cf4f0d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hide"",
                    ""type"": ""Button"",
                    ""id"": ""aaa9512e-b757-4417-9fe3-8c0fe1138bbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""ee404c9d-8430-4abc-afcc-0b28dd53433c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""9cda5193-49aa-4f5b-8053-5d4804911375"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""f55c714a-ed3d-44ad-a773-f59ff69a291a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Store"",
                    ""type"": ""Button"",
                    ""id"": ""2affe17e-cf76-49d1-b6f3-62d7f3722575"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4a0d1123-69a5-4b45-a91a-470e89fbf795"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""675c19b4-0721-47f4-8d40-7dc355ccd4e5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jerk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d7182f1b-68f0-4327-af51-dbd438a4f90f"",
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
                    ""id"": ""4c96d942-9eae-45bc-83c7-ca7edfe0bafb"",
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
                    ""id"": ""c028daad-20fe-47bb-a722-24f5aa567c4f"",
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
                    ""id"": ""ebf8b7fd-de51-448d-910d-47e39b30b01f"",
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
                    ""id"": ""3958e68f-5c12-4363-a835-ebac4ecfafdf"",
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
                    ""id"": ""ec854bd8-d8a1-4094-8ca2-71c4ac9a159d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1ea91cf-2bdc-4172-8615-7c027a9e7dd6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1635b12b-8b27-43a8-b57c-8ebda9bc7a9f"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bef5eaf3-49f7-4486-ae5b-a28dfa5f8d4b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2961a27a-aed0-4c7e-aa77-030e3ffa65c9"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c7fd437-195e-466c-8984-029bb9c7a101"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Store"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerInputControl"",
            ""bindingGroup"": ""PlayerInputControl"",
            ""devices"": []
        }
    ]
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Move = m_Keyboard.FindAction("Move", throwIfNotFound: true);
        m_Keyboard_Attack = m_Keyboard.FindAction("Attack", throwIfNotFound: true);
        m_Keyboard_Jerk = m_Keyboard.FindAction("Jerk", throwIfNotFound: true);
        m_Keyboard_Hide = m_Keyboard.FindAction("Hide", throwIfNotFound: true);
        m_Keyboard_Save = m_Keyboard.FindAction("Save", throwIfNotFound: true);
        m_Keyboard_Load = m_Keyboard.FindAction("Load", throwIfNotFound: true);
        m_Keyboard_Inventory = m_Keyboard.FindAction("Inventory", throwIfNotFound: true);
        m_Keyboard_Store = m_Keyboard.FindAction("Store", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Move;
    private readonly InputAction m_Keyboard_Attack;
    private readonly InputAction m_Keyboard_Jerk;
    private readonly InputAction m_Keyboard_Hide;
    private readonly InputAction m_Keyboard_Save;
    private readonly InputAction m_Keyboard_Load;
    private readonly InputAction m_Keyboard_Inventory;
    private readonly InputAction m_Keyboard_Store;
    public struct KeyboardActions
    {
        private @PlayerInputControls m_Wrapper;
        public KeyboardActions(@PlayerInputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Keyboard_Move;
        public InputAction @Attack => m_Wrapper.m_Keyboard_Attack;
        public InputAction @Jerk => m_Wrapper.m_Keyboard_Jerk;
        public InputAction @Hide => m_Wrapper.m_Keyboard_Hide;
        public InputAction @Save => m_Wrapper.m_Keyboard_Save;
        public InputAction @Load => m_Wrapper.m_Keyboard_Load;
        public InputAction @Inventory => m_Wrapper.m_Keyboard_Inventory;
        public InputAction @Store => m_Wrapper.m_Keyboard_Store;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnAttack;
                @Jerk.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJerk;
                @Jerk.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJerk;
                @Jerk.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJerk;
                @Hide.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHide;
                @Hide.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHide;
                @Hide.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHide;
                @Save.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSave;
                @Load.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLoad;
                @Inventory.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Store.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStore;
                @Store.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStore;
                @Store.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStore;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jerk.started += instance.OnJerk;
                @Jerk.performed += instance.OnJerk;
                @Jerk.canceled += instance.OnJerk;
                @Hide.started += instance.OnHide;
                @Hide.performed += instance.OnHide;
                @Hide.canceled += instance.OnHide;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Store.started += instance.OnStore;
                @Store.performed += instance.OnStore;
                @Store.canceled += instance.OnStore;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    private int m_PlayerInputControlSchemeIndex = -1;
    public InputControlScheme PlayerInputControlScheme
    {
        get
        {
            if (m_PlayerInputControlSchemeIndex == -1) m_PlayerInputControlSchemeIndex = asset.FindControlSchemeIndex("PlayerInputControl");
            return asset.controlSchemes[m_PlayerInputControlSchemeIndex];
        }
    }
    public interface IKeyboardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJerk(InputAction.CallbackContext context);
        void OnHide(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnStore(InputAction.CallbackContext context);
    }
}