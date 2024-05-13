using UnityEngine;
using UnityEngine.UI;

public class ActivateUIOnKey : MonoBehaviour
{
    public GameObject[] uiElements; // Array de elementos de la interfaz de usuario a activar/desactivar
    public Camera secondaryCamera; // Referencia a la c�mara secundaria
    public GameObject pauseMenu; // Referencia al men� de pausa
    private bool uiActive = false; // Estado de los elementos de la interfaz de usuario

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Comprueba si se ha presionado la tecla 2
        {
            // Comprueba si la c�mara secundaria est� activa y el men� de pausa no est� activo
            if (secondaryCamera != null && secondaryCamera.enabled && !pauseMenu.activeSelf)
            {
                uiActive = !uiActive; // Cambia el estado de la interfaz de usuario
                UpdateUIVisibility(); // Actualiza la visibilidad de los elementos
            }
        }
    }

    void UpdateUIVisibility()
    {
        foreach (var uiElement in uiElements)
        {
            uiElement.SetActive(uiActive); // Activa o desactiva los elementos seg�n el estado
        }
    }

    // M�todo para activar este script (llamado desde el men� de pausa)
    public void Activate()
    {
        enabled = true;
        UpdateUIVisibility();
    }

    // M�todo para desactivar este script (llamado desde el men� de pausa)
    public void Deactivate()
    {
        enabled = false;
        UpdateUIVisibility();
    }
}
