using UnityEngine;
using TMPro;

public class ManagerMision : MonoBehaviour
{
    public TextMeshProUGUI missionProgressText; // Referencia al texto de progreso de la misión en la UI
    private int completedMissions = 0; // Contador de misiones completadas

    void Start()
    {
        // Actualizar el texto de progreso de la misión al inicio
        UpdateMissionProgressText();
    }

    void Update()
    {
        // Aquí podrías agregar lógica adicional para supervisar la finalización de otras misiones
    }

    // Método para actualizar el texto de progreso de la misión en la UI
    void UpdateMissionProgressText()
    {
        // Actualizar el texto con el número de misiones completadas
        missionProgressText.text = "Favores: " + completedMissions.ToString() + "/5";
    }

    // Método para llamar cuando una misión se complete
    public void MissionCompleted()
    {
        completedMissions++; // Incrementar el contador de misiones completadas
        UpdateMissionProgressText(); // Actualizar el texto de progreso de la misión en la UI
    }
}
