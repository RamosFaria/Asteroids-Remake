using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private bool dash;
    public bool GetDash
    {
        get { return dash; }
    }
    private float horizontalRotation;
    public float GetHorizontal
    {
        get { return horizontalRotation; }
    }

    private bool shooting;
    public bool GetShooting
    {
        get { return shooting; }
    }
    private void Update()
    {
        dash = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        horizontalRotation = Input.GetAxisRaw("Horizontal");

        shooting = Input.GetKeyDown(KeyCode.Space);
    }
}
