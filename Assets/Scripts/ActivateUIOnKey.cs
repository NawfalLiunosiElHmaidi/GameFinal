using UnityEngine;
using UnityEngine.UI;

public class ActivateUIOnKey : MonoBehaviour
{
    public GameObject[] uiElements; // Array de elementos de la interfaz de usuario a activar/desactivar
    public Camera secondaryCamera; // Referencia a la cámara secundaria
    public GameObject pauseMenu; // Referencia al menú de pausa
    private bool uiActive = false; // Estado de los elementos de la interfaz de usuario

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Comprueba si se ha presionado la tecla 2
        {
            // Comprueba si la cámara secundaria está activa y el menú de pausa no está activo
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
            uiElement.SetActive(uiActive); // Activa o desactiva los elementos según el estado
        }
    }

    // Método para activar este script (llamado desde el menú de pausa)
    public void Activate()
    {
        enabled = true;
        UpdateUIVisibility();
    }

    // Método para desactivar este script (llamado desde el menú de pausa)
    public void Deactivate()
    {
        enabled = false;
        UpdateUIVisibility();
    }
}
