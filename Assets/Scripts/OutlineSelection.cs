using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectSelection : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private bool generatorActivated = false; // Variable para rastrear si el generador ha sido activado
    public TextMeshProUGUI interactableText;

    void Update()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit, 2))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                // Comprobar si el objeto es el generador y si ya ha sido activado antes
                if (highlight.name.Equals("Generador") && generatorActivated)
                {
                    interactableText.gameObject.SetActive(false);
                    highlight = null;
                    return;
                }

                raycastHit.collider.gameObject.GetComponent<Outline>().enabled = true;
                ShowInteractableText(GetInteractableText(highlight.gameObject));
            }
            else
            {
                interactableText.gameObject.SetActive(false);
                highlight = null;
            }
        }
        else
        {
            interactableText.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = raycastHit.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
        }
    }

    void ShowInteractableText(string text)
    {
        interactableText.text = text;
        interactableText.gameObject.SetActive(true);
    }

    string GetInteractableText(GameObject obj)
    {
        if (obj.name.Equals("Telefono"))
        {
            return "Llamar [E]";
        }
        else if (obj.name.Equals("Generador"))
        {
            return "Activar [E]";
        }
        else if (obj.name.Equals("Chest"))
        {
            return "Abrir [E]";
        }
        else if (obj.name.Equals("Mecader"))
        {
            return "Entregar cerillas [E]";
        }
        else
        {
            return "Coger [E]";
        }
    }

    // Método para activar el generador
    public void ActivateGenerator()
    {
        generatorActivated = true;
    }
}

