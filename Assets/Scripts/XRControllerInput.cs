using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using SWS;

public class XRControllerInput : MonoBehaviour
{
    
    private enum ControllerSide
    {
        Left_Controller,
        Right_Controller,
    }

    private enum ButtonPress
    {
        ButtonUp,
        ButtonDown,
        ButtonHeld,
    }

    [SerializeField]
    ControllerSide m_controller;
    InputDeviceCharacteristics m_characteristics;

    public splineMove splineTravel;
    bool isButtonPressed;
    bool isPaused = false; 
    ButtonPress xButton = ButtonPress.ButtonUp; // Number corrisponding to the state of the x button on the left controller   

    // Start is called before the first frame update
    void Start()
    {
        if(m_controller == ControllerSide.Left_Controller)
        {
            m_characteristics = InputDeviceCharacteristics.Left;
        }
        else
        {
            m_characteristics = InputDeviceCharacteristics.Right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<InputDevice> m_device = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(m_characteristics, m_device);
        if(m_device.Count == 1)
        {
            CheckController(m_device[0]);
        }
        else
        {
            //Debug.Log("Controller not found");
        }

        if(m_device.Count == 2)
        {
            CheckController(m_device[0]);
            CheckController(m_device[1]);
        }

        ///toggle player stop and go movement on the spline
        if(!isPaused && xButton == ButtonPress.ButtonDown)
        {
            splineTravel.Pause();
            isPaused = true;

            Debug.Log("Pausing spline move");
        }
        else if (isPaused && xButton == ButtonPress.ButtonDown)
        {
            splineTravel.Resume();
            isPaused = false;

            Debug.Log("Unpausing spline move");
        }



    }

    void CheckController(InputDevice d)
    {
        bool primaryButtonDown = false;
        d.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonDown);

        
        if (primaryButtonDown) /// "X" button on left controller or "A" button on right controller
        {
            Debug.Log("Button down");
            xButton++;

            if ((int)xButton > 1)
            {
                xButton = ButtonPress.ButtonHeld;
            }
        }
        else
        {
            Debug.Log("Button up");
            xButton = ButtonPress.ButtonUp;
        }

        bool triggerDown = false;
        d.TryGetFeatureValue(CommonUsages.triggerButton, out triggerDown);

        if (triggerDown)
        {
            Debug.Log("Trigger down");
        }
        else
        {
            Debug.Log("Trigger up");
        }
    }

}

/*
/// Check if the primary button (e.g., A or X) is pressed
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            Debug.Log("Primary button pressed");
            // Add your logic here for when the primary button is pressed
        }

/// Check if the secondary button (e.g., B or Y) is pressed
if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
{
    Debug.Log("Secondary button pressed");
    // Add your logic here for when the secondary button is pressed
}

/// Check if the trigger button is pressed
if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue) && triggerButtonValue)
{
    Debug.Log("Trigger button pressed");
    // Add your logic here for when the trigger button is pressed
}

    // Check if the grip button is pressed
    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue) && gripButtonValue)
    {
     Debug.Log("Grip button pressed");
     // Add your logic here for when the grip button is pressed
    }

*/
