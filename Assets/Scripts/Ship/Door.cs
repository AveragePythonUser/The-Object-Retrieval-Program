using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject trigger_front;
    [SerializeField]
    private Transform door;

    private static bool opening = false;
    private float vel;
    public float smooth_time;
    private static AudioSource source;

    private float slide_z;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
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
        source.Play();
    }

    public static void Close()
    {
        opening = false;
        source.Play();
    }
}
