// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/MyInput.inputactions'

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
                    ""type"": ""Button"",
                    ""id"": ""29e4fce8-55f8-44ad-b447-2fa9a323d070"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
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
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""3295bb4a-964c-4137-9479-42d6579fcd8c"",
            ""actions"": [
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""5e51931c-d53d-41d3-a069-b302d3668666"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""310ce04a-af68-40dd-ae8a-bc8c5e944652"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02d6f2f4-66d5-4e1d-9918-6285404b4368"",
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
                    ""id"": ""a835a2fd-fba4-4a9f-a2b2-862a6987ba0f"",
                    ""path"": ""<Keyboard>/#(X)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19144b48-3e44-40ee-a172-ae0d2901e779"",
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
                    ""id"": ""be2b492c-c86d-4a21-a9b6-7201a3d254bc"",
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
                    ""id"": ""f6fc803a-4a37-4145-b8d0-a30c702a2235"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Always"",
            ""id"": ""de2a9c8e-b661-4f08-9a86-981dfac0cc41"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""efe96ad5-1d5c-4c2a-9c87-05bbd1f89f81"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""SaveInput"",
                    ""type"": ""Value"",
                    ""id"": ""424ab82f-7d62-4ecc-9e96-7522fe61a505"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a87a130a-ff56-494d-9b32-10d7df24f3eb"",
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
                    ""id"": ""da792115-eda6-4938-ae37-36dd8212a67b"",
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
                    ""id"": ""6dec2cff-5bae-44e8-83d2-41f675ce3db5"",
                    ""path"": ""<DualShockGamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SaveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e781f2d-847d-4c62-8336-c43c9f036d60"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SaveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Test"",
            ""id"": ""dea60c61-12ea-4150-af03-2776a1550bc8"",
            ""actions"": [
                {
                    ""name"": ""Test1"",
                    ""type"": ""Value"",
                    ""id"": ""4332d97e-c066-4330-b0be-9126f97e16dd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Test2"",
                    ""type"": ""Button"",
                    ""id"": ""e03e0948-fe82-4db7-8ce9-0e75c557bd3e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Test3"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ebf1733f-a056-4875-aefe-4c99b3f9f483"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e470131f-b4cb-4b8a-9d50-f2c3c21cfebd"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Test3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""961ae943-e26e-437e-a907-d54f63203ee0"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Test1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4806b979-11ba-4d23-bf10-025aa82e9822"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Test2"",
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
        m_Basis_Cursor = m_Basis.GetAction("Cursor");
        // UI
        m_UI = asset.GetActionMap("UI");
        m_UI_Cancel = m_UI.GetAction("Cancel");
        m_UI_Enter = m_UI.GetAction("Enter");
        // Always
        m_Always = asset.GetActionMap("Always");
        m_Always_Menu = m_Always.GetAction("Menu");
        m_Always_SaveInput = m_Always.GetAction("SaveInput");
        // Test
        m_Test = asset.GetActionMap("Test");
        m_Test_Test1 = m_Test.GetAction("Test1");
        m_Test_Test2 = m_Test.GetAction("Test2");
        m_Test_Test3 = m_Test.GetAction("Test3");
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
    private readonly InputAction m_Basis_Cursor;
    public struct BasisActions
    {
        private MyInput m_Wrapper;
        public BasisActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Basis_Move;
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
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Enter;
    public struct UIActions
    {
        private MyInput m_Wrapper;
        public UIActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Enter => m_Wrapper.m_UI_Enter;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Enter.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEnter;
                Enter.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEnter;
                Enter.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Cancel.started += instance.OnCancel;
                Cancel.performed += instance.OnCancel;
                Cancel.canceled += instance.OnCancel;
                Enter.started += instance.OnEnter;
                Enter.performed += instance.OnEnter;
                Enter.canceled += instance.OnEnter;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Always
    private readonly InputActionMap m_Always;
    private IAlwaysActions m_AlwaysActionsCallbackInterface;
    private readonly InputAction m_Always_Menu;
    private readonly InputAction m_Always_SaveInput;
    public struct AlwaysActions
    {
        private MyInput m_Wrapper;
        public AlwaysActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_Always_Menu;
        public InputAction @SaveInput => m_Wrapper.m_Always_SaveInput;
        public InputActionMap Get() { return m_Wrapper.m_Always; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AlwaysActions set) { return set.Get(); }
        public void SetCallbacks(IAlwaysActions instance)
        {
            if (m_Wrapper.m_AlwaysActionsCallbackInterface != null)
            {
                Menu.started -= m_Wrapper.m_AlwaysActionsCallbackInterface.OnMenu;
                Menu.performed -= m_Wrapper.m_AlwaysActionsCallbackInterface.OnMenu;
                Menu.canceled -= m_Wrapper.m_AlwaysActionsCallbackInterface.OnMenu;
                SaveInput.started -= m_Wrapper.m_AlwaysActionsCallbackInterface.OnSaveInput;
                SaveInput.performed -= m_Wrapper.m_AlwaysActionsCallbackInterface.OnSaveInput;
                SaveInput.canceled -= m_Wrapper.m_AlwaysActionsCallbackInterface.OnSaveInput;
            }
            m_Wrapper.m_AlwaysActionsCallbackInterface = instance;
            if (instance != null)
            {
                Menu.started += instance.OnMenu;
                Menu.performed += instance.OnMenu;
                Menu.canceled += instance.OnMenu;
                SaveInput.started += instance.OnSaveInput;
                SaveInput.performed += instance.OnSaveInput;
                SaveInput.canceled += instance.OnSaveInput;
            }
        }
    }
    public AlwaysActions @Always => new AlwaysActions(this);

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_Test1;
    private readonly InputAction m_Test_Test2;
    private readonly InputAction m_Test_Test3;
    public struct TestActions
    {
        private MyInput m_Wrapper;
        public TestActions(MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Test1 => m_Wrapper.m_Test_Test1;
        public InputAction @Test2 => m_Wrapper.m_Test_Test2;
        public InputAction @Test3 => m_Wrapper.m_Test_Test3;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                Test1.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                Test1.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                Test1.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                Test2.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                Test2.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                Test2.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                Test3.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                Test3.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                Test3.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                Test1.started += instance.OnTest1;
                Test1.performed += instance.OnTest1;
                Test1.canceled += instance.OnTest1;
                Test2.started += instance.OnTest2;
                Test2.performed += instance.OnTest2;
                Test2.canceled += instance.OnTest2;
                Test3.started += instance.OnTest3;
                Test3.performed += instance.OnTest3;
                Test3.canceled += instance.OnTest3;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
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
        void OnCursor(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnCancel(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface IAlwaysActions
    {
        void OnMenu(InputAction.CallbackContext context);
        void OnSaveInput(InputAction.CallbackContext context);
    }
    public interface ITestActions
    {
        void OnTest1(InputAction.CallbackContext context);
        void OnTest2(InputAction.CallbackContext context);
        void OnTest3(InputAction.CallbackContext context);
    }
}
