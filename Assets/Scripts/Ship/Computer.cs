using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Text dot_X;
    private Text dot_Y;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("HUD").GetComponent<HUD_manager>();
        exit = GameObject.Find("Exit Button");
        Dot.transform.position = new Vector3(410f, 100f, 0);
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

    public void move_dot() // im sorry
    {
        Game_Events.check_event();
        if (Game_Events.object_number == 1)
            Dot.transform.position = new Vector3(62.6f, 68.8f, 0);
        else if (Game_Events.object_number == 2)
            Dot.transform.position = new Vector3(100f, 59.2f, 0);
        else if (Game_Events.object_number == 3)
            Dot.transform.position = new Vector3(400f, 300f, 0);
        else if (Game_Events.object_number == 4)
            Dot.transform.position = new Vector3(230f, 604f, 0);
        else if (Game_Events.object_number == 5)
            Dot.transform.position = new Vector3(600f, 20f, 0);
        else if (Game_Events.object_number == 6)
            Dot.transform.position = new Vector3(100f, 604f, 0);
        else if (Game_Events.object_number == 7)
            Dot.transform.position = new Vector3(500f, 30f, 0);
        else if (Game_Events.object_number == 8)
            Dot.transform.position = new Vector3(0f, 604f, 0);
        else if (Game_Events.object_number == 9)
            Dot.transform.position = new Vector3(10f, 10f, 0);
    }
}
