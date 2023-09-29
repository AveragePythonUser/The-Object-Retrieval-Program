using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    private HUD_manager manager;
    private GameObject exit;
    [SerializeField]
    private GameObject Dot;
    [SerializeField]
    private GameObject Scanner;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("HUD").GetComponent<HUD_manager>();
        exit = GameObject.Find("Exit Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit_Button()
    {
        manager.computer_shutdown();
    }

    public void Radar_Up()
    {
        Dot.transform.position += new Vector3(0, 6, 0);
    }

    public void Radar_Down() 
    {
        Dot.transform.position += new Vector3(0, -6, 0);
    }

    public void Scanner_Rotate_Right()
    {
        Scanner.transform.rotation *= Quaternion.Euler(0, 0, -3f);
    }
    public void Scanner_Rotate_Left()
    {
        Scanner.transform.rotation *= Quaternion.Euler(0, 0, 3f);
    }
}
