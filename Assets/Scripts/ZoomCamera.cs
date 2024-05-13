using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomSpeed = 10f; // Velocidad de zoom
    public float minFOV = 20f; // Valor m�nimo del campo de visi�n (zoom m�ximo)
    public float maxFOV = 60f; // Valor m�ximo del campo de visi�n (zoom m�nimo)

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Obtener la entrada de zoom del mouse (por ejemplo, la rueda del mouse)
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Aplicar el zoom multiplicando la entrada de zoom por la velocidad de zoom
        cam.fieldOfView += -zoomInput * zoomSpeed;

        // Limitar el campo de visi�n dentro del rango especificado
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
    }
}
