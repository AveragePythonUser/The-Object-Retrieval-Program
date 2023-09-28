using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UI;

public class HUD_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject E_panel;
    [SerializeField]
    private GameObject computer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(computer);
        turn_off_all();
        Press_E(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void turn_off_all()
    {
        computer.SetActive(false);
    }

    public void Press_E(bool state)
    {
        if (state == true)
            E_panel.SetActive(true);
        else
            E_panel.SetActive(false);
    }

    public void computer_initialize()
    {
        computer.SetActive(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void computer_shutdown()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        computer.SetActive(false);
    }
}
