using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move_button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject computer_object;
    private Computer computer;
    private bool is_pressed;
    public Text warning;
    // Start is called before the first frame update
    void Start()
    {
        computer = computer_object.GetComponent<Computer>();
        warning = GameObject.Find("Warning Text").GetComponent<Text>();
        Debug.Log(warning);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_pressed && Game_Events.can_move)
        {
            if (gameObject.name == "Up")
            {
                computer.Radar_Up();
            }
            else if (gameObject.name == "Back")
            {
                computer.Radar_Down();
            }
            else if (gameObject.name == "Left")
            {
                computer.Radar_Left();
            }
            else
            {
                computer.Radar_Right();
            }
            /* save for later
            if (Radar.object_in_scanner)
            {
                warning.text = "Error: cannot lock onto object while moving";
            } */
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        is_pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        is_pressed = false;
    }
}
