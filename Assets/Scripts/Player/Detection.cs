using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Detection : MonoBehaviour
{

    public Transform player_camera;
    [SerializeField]
    private int select_distance;
    public LayerMask layer;

    private HUD_manager hud_manager;
    
    // Start is called before the first frame update
    void Start()
    {
        hud_manager = GetComponent<HUD_manager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(player_camera.position, player_camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, select_distance))
        {
            if (hit.transform.gameObject.CompareTag("Selectable"))
            {
                hud_manager.Press_E(true);
                Selected();
            }
            else
            {
                hud_manager.Press_E(false);
            }
            
            Debug.Log("collide");
        }
        Debug.DrawRay(player_camera.position, player_camera.forward * select_distance, Color.yellow);

    }

    private void Selected()
    {
        Debug.Log("selected");
    }
}
