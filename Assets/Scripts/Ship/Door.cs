using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject trigger_front;
    [SerializeField]
    private GameObject trigger_back;
    [SerializeField]
    private Transform door;

    private static bool opening = false;
    private float vel;
    public float smooth_time;

    private float slide_z;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(opening == true)
        {
            slide_z = Mathf.SmoothDamp(door.position.z, 1f, ref vel, smooth_time);
        }
        else
        {
            slide_z = Mathf.SmoothDamp(door.position.z, gameObject.transform.position.z, ref vel, smooth_time);
        }
        door.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, slide_z);
    }

    public static void Open()
    {
        opening = true;
    }

    public static void Close()
    {
        opening = false;
    }
}
