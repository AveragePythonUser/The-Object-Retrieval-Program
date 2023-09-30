using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    private Text text;
    private Tasks tasks;
    public static bool object_in_scanner;
    // Start is called before the first frame update
    void Start()
    {
        // 
        text = GameObject.Find("In Range Text").GetComponent<Text>();
        tasks = GameObject.Find("Tasks").GetComponent<Tasks>();
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Radar Object"))
        {
            object_in_scanner = true;
            text.text = "object in range";
            tasks.Task_Object_In_Scanner();
            Debug.Log("Object in radar");
        }
    } */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Radar Object"))
        {
            object_in_scanner = true;
            text.text = "object in range";
            tasks.Task_Object_In_Scanner();
            Debug.Log("Object in radar");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Radar Object"))
        {
            object_in_scanner = false;
            text.text = "";
            tasks.Task_Reset_Text();
            Debug.Log("Object not in radar");
        }
    }
}
