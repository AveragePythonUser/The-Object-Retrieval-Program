using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    /// 
    /// credit for code
    /// https://www.youtube.com/watch?v=f473C43s8nE&t=217s
    /// 

    [Header("Movement")]
    public float move_speed;

    public float ground_drag;

    public float jump_force;
    public float jump_cool_down;
    public float air_multiplier;
    private bool ready_to_jump = true;

    [Header("Keybinds")]
    public KeyCode jump_key = KeyCode.Space;
    public KeyCode sprint_key = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float player_height;
    public LayerMask what_is_ground;
    [NonSerialized]
    public bool grounded;

    public Transform orientation;

    float horizontal_input;
    float vertical_input;

    Vector3 move_direction;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, player_height * 0.5f + 0.2f, what_is_ground);

        My_input();
        Speed_control();

        ///
        /// I removed this code that turns off drag when jumping. I want the movement
        /// to feel slow and sluggish. Doing chores should feel painfully slow.
        ///
        /*
         
        if (grounded == true)
        {
            rb.drag = ground_drag;
        }
        else
        {
            rb.drag = 0;
        } */
        rb.drag = ground_drag;

    }

    private void FixedUpdate()
    {
        Move_player();
    }

    private void My_input()
    {
        horizontal_input = Input.GetAxisRaw("Horizontal");
        vertical_input = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jump_key) && ready_to_jump && grounded)
        {
            Debug.Log("jump");
            ready_to_jump = false;
            Jump();

            Invoke(nameof(Reset_jump), jump_cool_down);
        }

        // sprint

        if (Input.GetKeyDown(sprint_key))
            move_speed = 8;
        else if (Input.GetKeyUp(sprint_key))
            move_speed = 5;
    }

    private void Move_player()
    {
        move_direction = orientation.forward * vertical_input + orientation.right * horizontal_input;
        rb.AddForce(move_direction * move_speed * 10f, ForceMode.Force);

        if(grounded == true)
        {
            rb.AddForce(move_direction.normalized * move_speed * 10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(move_direction.normalized * move_speed * 10f * air_multiplier, ForceMode.Force);
        }
    }

    private void Speed_control()
    {
        Vector3 flat_vel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flat_vel.magnitude > move_speed)
        {
            Vector3 limited_vel = flat_vel.normalized * move_speed;
            rb.velocity = new Vector3(limited_vel.x, rb.velocity.y, limited_vel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jump_force, ForceMode.Impulse);
    }

    private void Reset_jump()
    {
        ready_to_jump = true;
    }
}
