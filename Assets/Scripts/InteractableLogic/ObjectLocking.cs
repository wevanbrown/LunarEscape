using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLocking : MonoBehaviour
{

    // Update is called once per frame

    public Interactable interactable;
    void Start() {
        interactable.ToggleLocked();
    }

    void Unlock()
    {
        interactable.ToggleLocked();
    }
}
