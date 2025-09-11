using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SofthouseXML;
using System.Text.RegularExpressions;
using System.Linq;
public class InputController : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;

    [SerializeField]
    TextOutputController outputController;

    InputSerializer inputSerializer = new InputSerializer();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ParseTextInput()
    {
        Debug.Log("--- SanitizeInput started ---");
        var sanitizedInput = SanitizeInput(inputField.text);
        Debug.Log("--- SanitizeInput completed ---");


        Debug.Log("--- ParseInput Started ---");
        var res = inputSerializer.ParseInput(sanitizedInput);
        Debug.Log("--- ParseInput completed ---");

        Debug.Log("--- ConvertToXml Started ---");
        var xmlResult = new ToXml().Transform(res);
        Debug.Log("--- ConvertToXml completed ---");

        Debug.Log("--- Running DisplayText ---");
        outputController.DisplayText(xmlResult);

    }

    string SanitizeInput(string rawInput)
    {
        if (string.IsNullOrEmpty(rawInput))
        {
            return "";
        }

        //Fixar alla olika line endings, CRFL, LF etc.
        string normalizedNewlines = rawInput.Replace("\r\n", "\n").Replace("\r", "\n");

        var lines = normalizedNewlines.Split('\n');

        var sanitizedLines = lines
            //Plockar bort alla tabbar och trailing whitespaces
            .Select(line => line.Replace("\t", "").Trim())
            //Plockar bort tomma rader
            .Where(line => !string.IsNullOrEmpty(line));

        return string.Join("\n", sanitizedLines);
    }
}
