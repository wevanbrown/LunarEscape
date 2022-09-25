using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactor : MonoBehaviour
{

    public LayerMask interactableLayerMask = 6;
    public Image interactImage;
    public Sprite defaultIcon;
    public Sprite defaultInteractIcon;
    public Sprite lockedIcon;
    public Vector2 defaultIconSize;
    public Vector2 defaultInteractIconSize;
    public AudioSource audioSource;
    Interactable interactable;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
        {
            Debug.Log("Hit");
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }

                if (interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if (interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                    }
                    else
                    {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize;
                    }
                    if (interactable.locked)
                    {
                        interactImage.sprite = lockedIcon;
                    }
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if (interactable.interactText != null)
                {
                    interactable.interactText.enabled = true;
                }
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && interactable.locked == false)
                {
                    interactable.onInteract.Invoke();
                }
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && interactable.locked == true)
                {
                    audioSource.Play();
                }
            }


        }
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
            if (interactable != null && interactable.interactText != null)
            {
                interactable.interactText.enabled = false;
            }
        }


    }
}
