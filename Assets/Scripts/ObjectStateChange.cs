using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStateChange : MonoBehaviour
{

    Material mat;
    Color32 colorOriginal;
    
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        colorOriginal = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void RestoreColor()
    {
        GetComponent<Renderer>().material.color = colorOriginal;
    }
}
