using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Camera playerCamera; // Referencia a la cámara del jugador
    public float bobbingSpeed = 0.18f; // Velocidad del head bobbing
    public float standingBobbingAmount = 0.2f; // Cantidad de head bobbing cuando está de pie
    public float crouchingBobbingAmount = 0.1f; // Cantidad de head bobbing cuando está agachado
    public float breathingAmount = 0.05f; // Cantidad de movimiento adicional al respirar

    private float defaultPosY = 0f;
    private float timer = 0f;
    private float breathingTimer = 0f;
    private float breathingFrequency = 3f; // Frecuencia de la respiración en segundos
    private float breathingIntensity = 0f; // Intensidad de la respiración
    private bool isCrouching = false; // Variable para controlar si el jugador está agachado

    void Start()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player camera reference not set!");
            enabled = false; // Desactiva el script si no se asigna una cámara
            return;
        }

        defaultPosY = playerCamera.transform.localPosition.y;
    }

    void Update()
    {
        // Calcula el movimiento vertical del head bobbing usando una función seno
        float waveslice = Mathf.Sin(timer);
        float bobbingAmount = isCrouching ? crouchingBobbingAmount : standingBobbingAmount;

        if (Mathf.Abs(waveslice) > 0.01)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange *= totalAxes;
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultPosY + translateChange + breathingIntensity, playerCamera.transform.localPosition.z);
        }
        else
        {
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultPosY + breathingIntensity, playerCamera.transform.localPosition.z);
        }

        // Incrementa el temporizador del head bobbing
        timer += bobbingSpeed * Time.deltaTime;
        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }

        // Calcula la intensidad de la respiración
        breathingTimer += Time.deltaTime;
        if (breathingTimer >= breathingFrequency)
        {
            breathingIntensity = Mathf.Lerp(0f, breathingAmount, Mathf.PingPong(Time.time * 2f, 1f));
            breathingTimer = 0f;
        }

    }
}
