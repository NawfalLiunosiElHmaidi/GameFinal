using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public Animator door;
    public AudioSource doorSound;
    public Outline outline; // Referencia al componente Outline

    public bool inReach;

    void Start()
    {
        inReach = false;
        if (outline != null)
        {
            outline.enabled = false; // Desactivar el Outline al inicio
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            if (outline != null)
            {
                outline.enabled = true; // Activar el Outline al entrar en el rango de alcance
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            if (outline != null)
            {
                outline.enabled = false; // Desactivar el Outline al salir del rango de alcance
            }
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
    }

    void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
    }

    void DoorCloses()
    {
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
    }
}
