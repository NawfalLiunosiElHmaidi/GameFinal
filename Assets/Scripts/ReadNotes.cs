using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;


public class ReadNotes : MonoBehaviour
{
    public GameObject noteUI;

    public GameObject pickUpText;

    public bool inReach;

    public Outline outline; // Referencia al componente Outline




    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
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
            pickUpText.SetActive(true);
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
            pickUpText.SetActive(false);
            if (outline != null)
            {
                outline.enabled = false; // Desactivar el Outline al salir del rango de alcance
            }
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            pickUpText.SetActive(false);
            noteUI.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
            Cursor.lockState = CursorLockMode.None; // Libera el cursor
            Cursor.visible = true;
        }
        
    }
}
