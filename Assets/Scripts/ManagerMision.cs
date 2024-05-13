using UnityEngine;
using TMPro;

public class ManagerMision : MonoBehaviour
{
    public TextMeshProUGUI missionProgressText; // Referencia al texto de progreso de la misi�n en la UI
    private int completedMissions = 0; // Contador de misiones completadas

    void Start()
    {
        // Actualizar el texto de progreso de la misi�n al inicio
        UpdateMissionProgressText();
    }

    void Update()
    {
        // Aqu� podr�as agregar l�gica adicional para supervisar la finalizaci�n de otras misiones
    }

    // M�todo para actualizar el texto de progreso de la misi�n en la UI
    void UpdateMissionProgressText()
    {
        // Actualizar el texto con el n�mero de misiones completadas
        missionProgressText.text = "Favores: " + completedMissions.ToString() + "/5";
    }

    // M�todo para llamar cuando una misi�n se complete
    public void MissionCompleted()
    {
        completedMissions++; // Incrementar el contador de misiones completadas
        UpdateMissionProgressText(); // Actualizar el texto de progreso de la misi�n en la UI
    }
}
