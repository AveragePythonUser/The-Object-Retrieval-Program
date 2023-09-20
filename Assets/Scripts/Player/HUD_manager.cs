using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UI;

public class HUD_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject E_panel; 
    // Start is called before the first frame update
    void Start()
    {
        Press_E(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press_E(bool state)
    {
        if (state == true)
            E_panel.SetActive(true);
        else
            E_panel.SetActive(false);
    }
}
