using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private GameObject scanner;
    // Start is called before the first frame update
    void Start()
    {
        scanner = GameObject.Find("Scanner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Radar Object"))
        {
            Debug.Log("Object in radar");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Radar Object"))
        {
            Debug.Log("Object not in radar");
        }
    }
}
