using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SofthouseXML;
using System;

public class TextOutputController : MonoBehaviour
{
    [SerializeField]
    TMP_InputField textField;

    [SerializeField]
    [Range(1, 100)]
    int charsPerUpdate = 10;

    [SerializeField]
    bool instantDisplay = false;

    private string remainingTextToDisplay = "";

    public void DisplayText(string text)
    {
        remainingTextToDisplay = text;
        textField.text = "";
    }

    void Update()
    {
        if (remainingTextToDisplay.Length <= 0)
            return;

        if (instantDisplay)
            ShowText(remainingTextToDisplay.Length);
        else
            ShowText(charsPerUpdate);
    }

    private void ShowText(int attemptToDisplay)
    {
        var charsToDisplay = Math.Min(remainingTextToDisplay.Length, attemptToDisplay);
        var textToDisplay = remainingTextToDisplay.Substring(0, charsToDisplay);

        if (charsToDisplay < attemptToDisplay)
        {
            remainingTextToDisplay = "";
            Debug.Log("All text should now have been displayed");
        }
        else
        {
            var remaining = remainingTextToDisplay.Substring(attemptToDisplay);
            remainingTextToDisplay = remaining;
            Debug.Log($"Displaying: {charsToDisplay} chars, remaining: {remaining.Length}");
        }

        textField.text += textToDisplay;
    }
}
