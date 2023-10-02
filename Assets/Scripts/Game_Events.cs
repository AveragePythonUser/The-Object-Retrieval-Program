using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Events : MonoBehaviour
{
    // script to hold static variables and handle in game events

    public static int object_number = 0; // tracks how many times the player has
                                         // a space object
    public static bool engine_failure = false;
    public static bool engine_progress = false; // makesure audion sources dont play twice idk

    public static bool unknown_entity = false;
    public static bool at_computer = false;

    public static bool tutorial = false;

    // non game event variables
    public static bool can_move = true;

    public static void check_event()
    {
        Debug.Log(object_number);
        if (object_number == 3 || object_number == 6) 
        { 
            engine_failure = true;
            engine_progress = true;
            can_move = false;
        }
        else if (object_number == 10)
        {
            unknown_entity = true;
            can_move = false;
        }
    }
}
