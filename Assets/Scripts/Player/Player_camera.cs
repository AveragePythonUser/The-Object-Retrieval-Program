using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_camera : MonoBehaviour
{

    /// 
    /// credit to this video for code
    /// https://www.youtube.com/watch?v=f473C43s8nE&t=1s
    ///

    public float sensitivity_X;
    public float sensitivity_Y;

    public Transform orientation;

    float rotation_X;
    float rotation_Y;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity_X;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity_Y;

        rotation_Y += mouseX;
        rotation_X -= mouseY;

        rotation_X = Mathf.Clamp(rotation_X, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotation_X, rotation_Y, 0);
        orientation.rotation = Quaternion.Euler(0, rotation_Y, 0);
    }
}
