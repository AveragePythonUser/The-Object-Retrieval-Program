using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    private Text text;
    private Text warning_text;
    private Tasks tasks;
    private AudioSource source;
    public static bool object_in_scanner = false;

    private Voice_Lines voice;
    // Start is called before the first frame update
    void Start()
    {
        // 
        text = GameObject.Find("In Range Text").GetComponent<Text>();
        warning_text = GameObject.Find("Warning Text").GetComponent<Text>();
        tasks = GameObject.Find("Tasks").GetComponent<Tasks>();
        source = GameObject.Find("Scanner Image").GetComponent<AudioSource>();

        voice = GameObject.FindGameObjectWithTag("Voice").GetComponent<Voice_Lines>();
    }

    void Update()
    {
        if (Game_Events.engine_failure)
        {
            warning_text.text = "Warning, Engine offline. Please reset";
        }
        else
        {
            warning_text.text = string.Empty;
        }
    }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Radar Object") && object_in_scanner == false)
        {
            Debug.Log("radar audio");
            object_in_scanner = true;
            source.Play();

            if (Game_Events.tutorial)
                voice.play_clip("3");
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
