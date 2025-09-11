using UnityEngine;
using TMPro;

public class InGameConsole : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField consoleInputField;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        consoleInputField.text = $"[{type}] {logString}\n{consoleInputField.text}";
    }
}