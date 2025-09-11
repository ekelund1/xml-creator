using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SofthouseXML;
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
        Debug.Log("--- ParseInput Started ---");
        var res = inputSerializer.ParseInput(inputField.text);
        Debug.Log("--- ParseInput completed ---");

        Debug.Log("--- ConvertToXml Started ---");
        var xmlResult = new ToXml().Transform(res);
        Debug.Log("--- ConvertToXml completed ---");

        Debug.Log("--- Running DisplayText ---");
        outputController.DisplayText(xmlResult);

    }
}
