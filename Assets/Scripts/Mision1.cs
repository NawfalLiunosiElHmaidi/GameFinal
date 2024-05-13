using UnityEngine;
using TMPro;

public class Mision1 : MonoBehaviour
{
    public ManagerMision managerMision; // Referencia al ManagerMision
    public GameObject door1; // Puerta que se desbloqueará al recolectar los papeles
    public GameObject door2; // Puerta que se desbloqueará al recolectar los papeles
    public TextMeshProUGUI paperCountText; // Referencia al texto de papeles recogidos en la UI
    public Mision2 mision2; // Referencia al script Mision2

    private int paperCount = 0; // Contador de papeles recolectados
    private bool canCollectPaper = false; // Variable para controlar si se puede recolectar el papel
    private Transform paperToCollect; // Referencia al papel que se puede recolectar
    private bool missionCompleted = false; // Variable para controlar si la misión está completada

    void Start()
    {
        UpdatePaperCountText();
    }

    void Update()
    {
        // Si la misión está completada, desactivar el texto y activar el texto en Mision2
        if (missionCompleted)
        {
            DisablePaperCountText();
            mision2.ActivateJarText();
        }
        else
        {
            // Raycast para detectar papeles
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
            {
                // Verificar si el objeto detectado es un papel
                if (hit.collider.gameObject.name == "PaperMision")
                {
                    paperToCollect = hit.transform;
                    canCollectPaper = true;
                }
            }

            // Recolectar el papel al presionar la tecla E
            if (canCollectPaper && Input.GetKeyDown(KeyCode.E))
            {
                CollectPaper();
            }
        }
    }

    void CollectPaper()
    {
        // Incrementar el contador de papeles recolectados
        paperCount++;

        // Actualizar el texto en la UI
        UpdatePaperCountText();

        // Destruir el papel recolectado
        Destroy(paperToCollect.gameObject);

        // Reiniciar la variable para la próxima detección de papel
        canCollectPaper = false;

        // Si se recolectan tres papeles, desbloquear la puerta y marcar la misión como completada
        if (paperCount >= 3)
        {
            OpenDoor();
            missionCompleted = true;

            // Llamar al método MissionCompleted del ManagerMision
            managerMision.MissionCompleted();
        }
    }

    void OpenDoor()
    {
        // Desactivar las puertas
        door1.SetActive(false);
        door2.SetActive(false);
    }

    void UpdatePaperCountText()
    {
        // Actualizar el texto de los papeles recogidos en la UI
        paperCountText.text = "Papeles Recogidos: " + paperCount.ToString() + "/3";
    }

    void DisablePaperCountText()
    {
        // Desactivar el texto de los papeles recogidos en la UI
        paperCountText.gameObject.SetActive(false);
    }
}

