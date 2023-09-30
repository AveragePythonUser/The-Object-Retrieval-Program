using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate_button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject computer_object;
    private Computer computer;
    private bool is_pressed;
    // Start is called before the first frame update
    void Start()
    {
        computer = computer_object.GetComponent<Computer>();
    }

    void FixedUpdate()
    {
        if (is_pressed)
        {
            if (gameObject.name == "Rotate Right")
            {
                computer.Scanner_Rotate_Right();
            }
            else
            {
                computer.Scanner_Rotate_Left();
            }
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
