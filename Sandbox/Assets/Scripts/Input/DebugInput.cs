// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/DebugInput.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class DebugInput : IInputActionCollection
{
    private InputActionAsset asset;
    public DebugInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DebugInput"",
    ""maps"": [
        {
            ""name"": ""Debug"",
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
                },
                {
                    ""name"": ""SaveInput"",
                    ""type"": ""Value"",
                    ""id"": ""3ad5d372-b6b9-4224-a839-797b81897788"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
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
                },
                {
                    ""name"": """",
                    ""id"": ""f7c096a3-e176-48d4-a1cc-deabf8db0312"",
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
                    ""id"": ""7be5dba8-1895-4d94-9ff5-8e272dc07199"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SaveInput"",
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
        // Debug
        m_Debug = asset.GetActionMap("Debug");
        m_Debug_Test1 = m_Debug.GetAction("Test1");
        m_Debug_Test2 = m_Debug.GetAction("Test2");
        m_Debug_Test3 = m_Debug.GetAction("Test3");
        m_Debug_SaveInput = m_Debug.GetAction("SaveInput");
    }

    ~DebugInput()
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

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Test1;
    private readonly InputAction m_Debug_Test2;
    private readonly InputAction m_Debug_Test3;
    private readonly InputAction m_Debug_SaveInput;
    public struct DebugActions
    {
        private DebugInput m_Wrapper;
        public DebugActions(DebugInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Test1 => m_Wrapper.m_Debug_Test1;
        public InputAction @Test2 => m_Wrapper.m_Debug_Test2;
        public InputAction @Test3 => m_Wrapper.m_Debug_Test3;
        public InputAction @SaveInput => m_Wrapper.m_Debug_SaveInput;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                Test1.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest1;
                Test1.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest1;
                Test1.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest1;
                Test2.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest2;
                Test2.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest2;
                Test2.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest2;
                Test3.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest3;
                Test3.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest3;
                Test3.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnTest3;
                SaveInput.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSaveInput;
                SaveInput.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSaveInput;
                SaveInput.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSaveInput;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
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
                SaveInput.started += instance.OnSaveInput;
                SaveInput.performed += instance.OnSaveInput;
                SaveInput.canceled += instance.OnSaveInput;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
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
    public interface IDebugActions
    {
        void OnTest1(InputAction.CallbackContext context);
        void OnTest2(InputAction.CallbackContext context);
        void OnTest3(InputAction.CallbackContext context);
        void OnSaveInput(InputAction.CallbackContext context);
    }
}
