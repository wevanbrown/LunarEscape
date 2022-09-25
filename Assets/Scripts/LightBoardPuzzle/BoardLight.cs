using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLight : MonoBehaviour
{
    public Light buttonLight;
    public Color32 panicColor;
    public Color32 correctColor;
    public bool panicked;
    
    void Start() 
    {
        if(panicked)
        {
            buttonLight.color = panicColor;
        }
        else
        {
            buttonLight.color = correctColor;
        }
    }
    void ToggleLight()
    {
        if (buttonLight.color == panicColor)
        {
            buttonLight.color = correctColor;
        }
        else
        {
            buttonLight.color = panicColor;
        }
    }
}
