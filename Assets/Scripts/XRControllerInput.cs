using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRControllerInput : MonoBehaviour
{
    
    private enum ControllerSide
    {
        Left_Controller,
        Right_Controller,
    }

    [SerializeField]
    ControllerSide m_controller;
    InputDeviceCharacteristics m_characteristics;

    

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
            Debug.Log("Controller not found");
        }
    }

    void CheckController(InputDevice d)
    {
        bool primaryButtonDown = false;
        d.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonDown);
        if (primaryButtonDown)
        {
            Debug.Log("Button down");
        }
        else
        {
            Debug.Log("Button up");
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
