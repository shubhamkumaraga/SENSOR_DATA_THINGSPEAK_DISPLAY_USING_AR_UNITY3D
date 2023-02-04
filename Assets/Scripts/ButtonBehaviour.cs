using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBehaviour : MonoBehaviour
{
    public string jsonURL;
    private string field1Data;
    private string field2Data;
    public TextMeshProUGUI displayText;
    public Button humidityButton;
    public Button temperatureButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData());
        humidityButton.onClick.AddListener(DisplayHumidity); 
        temperatureButton.onClick.AddListener(DisplayTemperature);
    }

    IEnumerator getData()
    {
        Debug.Log("Processing Data, Please Wait...");
        WWW _www = new WWW(jsonURL);
        yield return _www;
        if(_www.error == null)
        {
            processJsonData1(_www.text);
            processJsonData2(_www.text);
        }
        else
        {
            Debug.Log("Oops! Something went wrong");
        }
    }

    public string processJsonData1(string _url)
    {
        JsonFormat jsonData = JsonUtility.FromJson<JsonFormat>(_url);
        foreach (feedData item in jsonData.feeds)
        {
            field1Data = item.field1;
        }
        return field1Data;
    }

    public string processJsonData2(string _url)
    {
        JsonFormat jsonData = JsonUtility.FromJson<JsonFormat>(_url);
        foreach (feedData item in jsonData.feeds)
        {
            field2Data = item.field2;
        }
        return field2Data;
    }

    void DisplayHumidity()
    {
        displayText.text = "Humidity: "+field1Data;
    }

    void DisplayTemperature()
    {
        displayText.text = "Temperature: "+field2Data;
    }
}
