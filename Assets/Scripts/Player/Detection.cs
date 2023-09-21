using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Detection : MonoBehaviour
{

    [Header("Binds")]
    public KeyCode Key_E = KeyCode.E;

    [Header("Other")]
    public Transform player_camera;
    [SerializeField]
    private int select_distance;
    public LayerMask layer;

    // Objects and Components
    private HUD_manager hud_manager;
    private Transform orientation;

    private bool holding;
    private Transform holding_transform;
    
    // Start is called before the first frame update
    void Start()
    {
        hud_manager = GameObject.Find("HUD").GetComponent<HUD_manager>();
        orientation = GameObject.Find("Orientation").GetComponent<Transform>();
    }

    private void Update()
    {
        if (holding == true)
        {
            holding_object();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        select_check();
    }

    private void holding_object()
    {
        holding_transform.position = gameObject.transform.position + new Vector3(3, 0, 0);
        //holding_transform.position = player_camera.transform.forward;
    }

    private void select_check()
    {
        Ray ray = new Ray(player_camera.position, player_camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, select_distance))
        {
            if (hit.transform.gameObject.CompareTag("Selectable"))
            {
                hud_manager.Press_E(true);
                Selected(hit);
            }
        }
        else
        {
            hud_manager.Press_E(false);
        }
        Debug.DrawRay(player_camera.position, player_camera.forward * select_distance, Color.yellow);
    }

    private void Selected(RaycastHit hit)
    {
        if (Input.GetKey(Key_E))
        {
            holding = true;
            holding_transform = hit.transform;
        }

    }
}
