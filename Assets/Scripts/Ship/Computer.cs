using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    private HUD_manager manager;
    private GameObject exit;
    private GameObject Dot;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("HUD").GetComponent<HUD_manager>();
        exit = GameObject.Find("Exit Button");
        Dot = GameObject.Find("Dot");
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
        Dot.transform.position += new Vector3(0, 1, 0);
    }
}
