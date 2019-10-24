using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class ProcessorISX : MonoBehaviour
{
    [Header("The Input Action with Processors")]
    public InputAction m_inputAction;

    [Header("UI element for more info")]
    public Text m_originalText;
    public Text m_resultText;
    public Image m_stickImage = null;

    protected int m_stickImageOffsetFactor = 12;

    protected abstract void UpdateResult();
}
