using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
    }
    public void Task_Change_Text(string str_text)
    {
        text.text = str_text;
    }
    public void Task_Reset_Text()
    {
        text.text = "";
    }
    public void Task_Object_In_Scanner()
    {
        text.text = "Please Retrieve Object at retrieval station";
    }
}
