using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private HUD_manager manager;
    private GameObject exit;
    [SerializeField]
    private GameObject Dot;
    [SerializeField]
    private GameObject Scanner;
    [SerializeField]
    private float rotate_speed;
    [SerializeField]
    private float move_speed;

    public static int object_number = 0; // tracks how many times the player has
                                         // a space object

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("HUD").GetComponent<HUD_manager>();
        exit = GameObject.Find("Exit Button");
    }

    public void Exit_Button()
    {
        manager.computer_shutdown();
    }

    public void Radar_Up()
    {
        Dot.transform.position += new Vector3(0, -move_speed, 0);
    }

    public void Radar_Down() 
    {
        Dot.transform.position += new Vector3(0, move_speed, 0);
    }

    public void Radar_Left()
    {
        Dot.transform.position += new Vector3(move_speed, 0, 0);
    }

    public void Radar_Right()
    {
        Dot.transform.position += new Vector3(-move_speed, 0, 0);
    }

    public void Scanner_Rotate_Right()
    {
        Scanner.transform.rotation *= Quaternion.Euler(0, 0, -rotate_speed);
    }
    public void Scanner_Rotate_Left()
    {
        Scanner.transform.rotation *= Quaternion.Euler(0, 0, rotate_speed);
    }

    public void move_dot()
    {
        if (object_number == 1)
            Dot.transform.position = new Vector3(62.6f, 68.8f, 0);
    }
}
