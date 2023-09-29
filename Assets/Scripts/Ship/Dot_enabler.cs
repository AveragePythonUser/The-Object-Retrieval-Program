using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot_enabler : MonoBehaviour
{
    [SerializeField]
    private GameObject dot_image;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Radar Object"))
        {
            dot_image.SetActive(true);
        }
        Debug.Log("enter");
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("exit");
        if (collider.CompareTag("Radar Object"))
        {
            dot_image.SetActive(false);
        }
    }
}
