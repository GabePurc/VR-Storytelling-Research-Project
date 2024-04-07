using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;

    public InputActionProperty leftActivate;


    void Update()
    {
        leftTeleportation.SetActive(leftActivate.action.ReadValue<Vector2>().y > 0.1f);
    }
}
