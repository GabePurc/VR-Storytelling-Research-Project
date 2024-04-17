using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    

    public float rotationSpeedX = 45.0f;  // Rotation speed in degrees per second around the X axis
    public float rotationSpeedY = 60.0f;  // Rotation speed in degrees per second around the Y axis
    public float rotationSpeedZ = 30.0f;  // Rotation speed in degrees per second around the Z axis

    void Update()
    {
        // Rotate around the X, Y, and Z axes independently at different speeds
        transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeedZ * Time.deltaTime);
    }

    public void StopRotation()
    {
        rotationSpeedX = 0f;
        rotationSpeedY = 0f;
        rotationSpeedZ = 0f;
    }

}
