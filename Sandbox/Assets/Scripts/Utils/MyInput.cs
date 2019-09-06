// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Utils/MyInput.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class MyInput : IInputActionCollection
{
    private InputActionAsset asset;
    public MyInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInput"",
    ""maps"": [
        {
            ""name"": ""Basis"",
            ""id"": ""686900d5-5379-406f-87dc-bd0e4077bcba"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""29e4fce8-55f8-44ad-b447-2fa9a323d070"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""8bf113b2-9bad-406b-9f3d-265ff37b2152"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Button"",
                    ""id"": ""149d54f1-47e2-41d5-a351-b3664912b73d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c6026425-a7ea-491f-87bf-d9e20751deee"",
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
                    ""path"": ""<DualShockGamepad>/rightStick/up"",
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
                    ""name"": """",
                    ""id"": ""a28bfad8-dcc7-465d-abea-b84652db9462"",
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
                    ""id"": ""819a556d-9955-40ff-98d3-4538f10ba529"",
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
                    ""id"": ""93e80602-aaa7-44f1-addd-cd156b1de604"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""3295bb4a-964c-4137-9479-42d6579fcd8c"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""5e51931c-d53d-41d3-a069-b302d3668666"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02d6f2f4-66d5-4e1d-9918-6285404b4368"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
        m_Basis = asset.GetActionMap("Basis");
        m_Basis_Move = m_Basis.GetAction("Move");
        m_Basis_Enter = m_Basis.GetAction("Enter");
        m_Basis_Cursor = m_Basis.GetAction("Cursor");
        // UI
        m_UI = asset.GetActionMap("UI");
        m_UI_Newaction = m_UI.GetAction("New action");
    }

    ~MyInput()
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
    private readonly InputAction m_Basis_Enter;
    private readonly InputAction m_Basis_Cursor;
    public struct BasisActions
    {
        private MyInput m_Wrapper;
        public BasisActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Basis_Move;
        public InputAction @Enter => m_Wrapper.m_Basis_Enter;
        public InputAction @Cursor => m_Wrapper.m_Basis_Cursor;
        public InputActionMap Get() { return m_Wrapper.m_Basis; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasisActions set) { return set.Get(); }
        public void SetCallbacks(IBasisActions instance)
        {
            if (m_Wrapper.m_BasisActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnMove;
                Enter.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnEnter;
                Enter.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnEnter;
                Enter.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnEnter;
                Cursor.started -= m_Wrapper.m_BasisActionsCallbackInterface.OnCursor;
                Cursor.performed -= m_Wrapper.m_BasisActionsCallbackInterface.OnCursor;
                Cursor.canceled -= m_Wrapper.m_BasisActionsCallbackInterface.OnCursor;
            }
            m_Wrapper.m_BasisActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Enter.started += instance.OnEnter;
                Enter.performed += instance.OnEnter;
                Enter.canceled += instance.OnEnter;
                Cursor.started += instance.OnCursor;
                Cursor.performed += instance.OnCursor;
                Cursor.canceled += instance.OnCursor;
            }
        }
    }
    public BasisActions @Basis => new BasisActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private MyInput m_Wrapper;
        public UIActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Newaction.started += instance.OnNewaction;
                Newaction.performed += instance.OnNewaction;
                Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.GetControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.GetControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IBasisActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
