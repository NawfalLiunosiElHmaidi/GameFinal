using UnityEngine;
using TMPro;

public class Mision5 : MonoBehaviour
{
    public TextMeshProUGUI GasText; // Referencia al texto de b�squeda de jarr�n
    public ManagerMision managerMision; // Referencia al ManagerMision
    public GameObject Gasolina;

    private bool canCollectGas = false; // Variable para controlar si se puede recolectar el objeto
    private Transform GasToCollect; // Referencia al objeto que se puede recolectar
    private bool missionCompleted = false; // Variable para controlar si la misi�n est� completada

    private void Start()
    {
        Gasolina.gameObject.SetActive(false);
        GasText.gameObject.SetActive(false);
    }

    public void ActivateGasText()
    {
        GasText.gameObject.SetActive(true);
        Gasolina.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (missionCompleted)
        {
            DisableGasText();
        }
        else
        {
            // Raycast para detectar objetos
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
            {
                // Verificar si el objeto detectado es el que queremos recolectar
                if (hit.collider.gameObject.name == "Gasolina")
                {
                    GasToCollect = hit.transform;
                    canCollectGas = true;
                }
            }

            // Recolectar el objeto al presionar la tecla E
            if (canCollectGas && Input.GetKeyDown(KeyCode.E))
            {
                CollectGas();
            }
        }
    }

    private void CollectGas()
    {
        // Destruir el objeto recolectado
        Destroy(GasToCollect.gameObject);

        // Marcar la misi�n como completada
        missionCompleted = true;

        // Llamar al m�todo MissionCompleted del ManagerMision
        managerMision.MissionCompleted();
    }

    private void DisableGasText()
    {
        // Desactivar el texto de b�squeda del jarr�n
        GasText.gameObject.SetActive(false);
    }
}