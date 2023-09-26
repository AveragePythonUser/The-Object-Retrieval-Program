using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_triggers : MonoBehaviour
{
    private Door door;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Door.Open();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.Close();
        }
    }
}
