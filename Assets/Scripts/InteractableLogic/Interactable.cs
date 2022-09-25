using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite interactIcon;
    public Vector2 iconSize;
    public Canvas interactText;
    public int ID;
    public bool locked;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 999999);
        if(interactText != null)
        {
            interactText.enabled = false;
        }
    }

    public void ToggleLocked()
    {
        this.locked = !this.locked;
    }

}
