using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MachineReset : MonoBehaviour
{
    public GameObject ResetText;

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
            ResetText.SetActive(true);
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
            ResetText.SetActive(false);
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
            // Reiniciar el nivel
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
