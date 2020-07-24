// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputScripts/BasisInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BasisInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BasisInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BasisInput"",
    ""maps"": [
        {
            ""name"": ""Basis"",
            ""id"": ""686900d5-5379-406f-87dc-bd0e4077bcba"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""29e4fce8-55f8-44ad-b447-2fa9a323d070"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""cfa932b9-fb62-4ba9-8e96-0c672a3e4369"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Button"",
                    ""id"": ""d9328b3f-2078-47f3-8496-681e73b98ca9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""1288d5fa-3cc1-4248-a1db-65fe2bff3795"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""149d54f1-47e2-41d5-a351-b3664912b73d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c6026425-a7ea-491f-87bf-d9e20751deee"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""32da9a9d-2dcc-4ad2-9c19-2095c221205c"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2023ad57-f277-477d-9254-4dadf241f90b"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81a20462-61a1-4861-8ff5-d01b077015b3"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8ce28fed-8bf6-4484-b91a-f2cef879f6c1"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""d44ebe93-f884-4fcc-8b03-f905b72a4dc1"",
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
                    ""id"": ""994eb772-757c-4e62-8c76-d290410b083f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f5619a68-a5b4-43bd-98fd-e06323325e59"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c5ca8719-105d-431f-8aaa-ecc57196f762"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8669a70b-349a-43e3-8a58-d8bbb7119bea"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""01bf7ef7-0f6a-4b62-9232-846e7635fde5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""40ced7b9-41a7-4c21-8f68-9b8884b79629"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dbf7174c-261a-4782-bf83-da6f6ec7272f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f2c83622-2532-4912-a8ff-cca1a3fd1a79"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bae8e5d8-84b1-45ea-8f71-3944db80e21e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Pad"",
                    ""id"": ""cd795759-559f-4edb-988d-f2aea7bdeefa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""626ad2c1-1db9-473b-8692-506f6a8c8dc2"",
                    ""path"": ""<DualShockGamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cc4ee4e-c67a-4676-b93e-d44a277459be"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36b1cd3a-efd1-4475-90ae-3f92831caf34"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5a6949df-7571-445a-a1dc-efe5b9ceb62f"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""20c0d0f2-bf8e-4d18-9a9a-a1134c9e5093"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07dce5ae-9f55-4027-8a10-888a3e560c3b"",
                    ""path"": ""<Keyboard>/#(C)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57c38c48-4533-43df-af4c-080856e431ae"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0424967-f354-43d1-acdf-3574857abb35"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daee1af4-394b-4ede-9de8-c8c0ebaa09b2"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8aad86a-4fab-4734-b08c-45f5c0e90e05"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e48b6d5-a20b-40b3-891f-aeda851f4371"",
                    ""path"": ""<Keyboard>/#(X)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Basis
        m_Basis = asset.FindActionMap("Basis", throwIfNotFound: true);
        m_Basis_Move = m_Basis.FindAction("Move", throwIfNotFound: true);
        m_Basis_Menu = m_Basis.FindAction("Menu", throwIfNotFound: true);
        m_Basis_Cursor = m_Basis.FindAction("Cursor", throwIfNotFound: true);
        m_Basis_Cancel = m_Basis.FindAction("Cancel", throwIfNotFound: true);
        m_Basis_Enter = m_Basis.FindAction("Enter", throwIfNotFound: true);
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

    // Basis
    private readonly InputActionMap m_Basis;
    private IBasisActions m_BasisActionsCallbackInterface;
    private readonly InputAction m_Basis_Move;
    private readonly InputAction m_Basis_Menu;
    private readonly InputAction m_Basis_Cursor;
    private readonly InputAction m_Basis_Cancel;
    private readonly InputAction m_Basis_Enter;
    public struct BasisActions
    {
        private @BasisInput m_Wrapper;
        public BasisActions(@BasisInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Basis_Move;
        public InputAction @Menu => m_Wrapper.m_Basis_Menu;
        public InputAction @Cursor => m_Wrapper.m_Basis_Cursor;
        public InputAction @Cancel => m_Wrapper.m_Basis_Cancel;
        public InputAction @Enter => m_Wrapper.m_Basis_Enter;
        public InputActionMap Get() { return m_Wrapper.m_Basis; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasisActions set) { return set.Get(); }
        public void SetCallbacks(IBasisActions instance)
        {
            if (m_Wrapper.m_BasisActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnMove;
                @Menu.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnMenu;
                @Cursor.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnCursor;
                @Cancel.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnCancel;
                @Enter.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_BasisActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public BasisActions @Basis => new BasisActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IBasisActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}
