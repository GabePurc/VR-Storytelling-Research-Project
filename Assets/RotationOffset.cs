using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOffset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(0f, currentRotation.y, 0f);
    }
}
