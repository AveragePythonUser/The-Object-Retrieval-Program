using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_holder : MonoBehaviour
{
    ///
    /// credit for code
    /// https://www.youtube.com/watch?v=f473C43s8nE&t=1s 
    ///

    public Transform camera_position;

    // Update is called once per frame
    void Update()
    {
        transform.position = camera_position.position;
    }
}
