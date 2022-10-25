using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// [RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{

    public GameObject interactIcon;

    public void Start()
    {
        this.interactIcon.SetActive(false);
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(collision.GetComponent<Player>());
            // collision.GetComponent<Player>().OpenInteractableIcon();
            this.interactIcon.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            // collision.GetComponent<Player>().CloseInteractableIcon();
            this.interactIcon.SetActive(false);
    }
    
    // public void OpenInteractableIcon()
    // {
    //     interactIcon.SetActive(true);
    // }
    //
    // public void CloseInteractableIcon()
    // {
    //     interactIcon.SetActive(false);
    // }
}
