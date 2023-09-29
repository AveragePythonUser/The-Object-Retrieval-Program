using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_button : MonoBehaviour
{
    public Computer computer;
    private bool is_pressed;
    // Start is called before the first frame update
    void Start()
    {
        computer = GameObject.Find("Computer").GetComponent<Computer>();
    }

    
    
}
