using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private Computer computer;
    private Transform orientation;
    private Transform hold_parent;

    private bool holding;
    private bool hold_ready;
    private Transform holding_transform;
    private bool analyze;
    [SerializeField]
    public GameObject engine;
    public Engine_fail engine_fail;
    private AudioSource source;

    private Voice_Lines voice;

    // Start is called before the first frame update
    void Start()
    {
        hud_manager = GameObject.Find("HUD").GetComponent<HUD_manager>();
        orientation = GameObject.Find("Orientation").GetComponent<Transform>();
        hold_parent = GameObject.Find("Holding").GetComponent<Transform>();
        computer = GameObject.Find("HUD").GetComponent<Computer>();
        engine_fail = engine.GetComponent<Engine_fail>();
        source = GetComponent<AudioSource>();

        voice = GameObject.FindGameObjectWithTag("Voice").GetComponent<Voice_Lines>();

        holding = false;
        hold_ready = true;
    }

    private void Update()
    {
        //check_binds();
        /*if (holding == true)
        {
            holding_object();
        } */
        if (analyze)
        {
            if (Input.GetKeyDown(Key_E))
                Analyze();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        select_check();
    }

    /*private void check_binds()
    {
        Ray ray = new Ray(player_camera.position, player_camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, select_distance) == false)
        { 
            if ((Input.GetKey(Key_E) && holding == true) && hold_ready == false)
            {
                holding = false;
                hold_ready = true;
                holding_transform.SetParent(null);
            }
        }
    } */

    private void hold_cooldown()
    {
        hold_ready = false;
    }

    private void holding_object()
    {
        // follows player looking direction. gameobject parent there so the cube rotates
        // around the player
        hold_parent.position = orientation.position;
        hold_parent.rotation = orientation.rotation;
        //holding_transform.position = new Vector3(0, 0, 3);
        //holding_transform.rotation = hold_parent.rotation;
    }

    private void select_check()
    {
        Ray ray = new Ray(player_camera.position, player_camera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, select_distance))
        {
            if (hit.transform.gameObject.CompareTag("Selectable"))
            {
                Debug.Log(Radar.object_in_scanner);
                if ((hit.transform.name == "Analyze") && Radar.object_in_scanner)
                {
                    hud_manager.Press_E(true);
                    analyze = true;
                }
                else if (hit.transform.name == "Engine Reset" && Game_Events.engine_failure == true)
                {
                    hud_manager.Press_E(true);
                    if (Input.GetKey(Key_E))
                        engine_fail.Stop_engine();
                }
            }
            else if(hit.transform.gameObject.CompareTag("Computer"))
            {
                hud_manager.Press_E(true);
                if (Input.GetKey(Key_E))
                    hud_manager.computer_initialize();
            }
        }
        else
        {
            hud_manager.Press_E(false);
            analyze = false;
        }
        Debug.DrawRay(player_camera.position, player_camera.forward * select_distance, Color.yellow);
    }

    /*private void Selected(RaycastHit hit)
    {
        if ((Input.GetKey(Key_E) && holding == false) && hold_ready == true)
        {
            holding = true;
            holding_transform = hit.transform;
            hold_parent.position = orientation.position;
            hold_parent.rotation = orientation.rotation;
            holding_transform.SetParent(hold_parent);
            Debug.Log("before" + holding_transform.position);
            //holding_transform.position = new Vector3(0, 0, 3);
            Debug.Log("after" + holding_transform.position);
            Invoke("hold_cooldown", 0.5f);
        }

    } */
    private void Analyze()
    {
        // play sound

        if (Game_Events.tutorial)
            voice.play_clip("4");

        Game_Events.object_number += 1;
        Radar.object_in_scanner = false;
        computer.move_dot();
        hud_manager.Press_E(false);
        source.Play();
        Debug.Log("hit");
    }
}
