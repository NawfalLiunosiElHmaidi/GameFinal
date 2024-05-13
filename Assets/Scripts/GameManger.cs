using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Ocultar y bloquear el cursor al comenzar
        Cursor.visible = false;
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor al finalizar
        Cursor.visible = true; // Hacer que el cursor sea visible
    }
}


