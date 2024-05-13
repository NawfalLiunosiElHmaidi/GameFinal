using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirNotas : MonoBehaviour
{
    public GameObject noteUI;

    public void ExitButtonNote()
    {
        noteUI.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false; // Oculta el cursor
    }
}
