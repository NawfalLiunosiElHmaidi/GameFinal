using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light luz; // Referencia al componente Light de la linterna
    public AudioClip encenderSound; // Sonido al encender la linterna
    public AudioClip apagarSound; // Sonido al apagar la linterna

    private AudioSource audioSource; // Componente para reproducir sonidos
    private bool encendida = false; // Variable para controlar el estado de la linterna

    void Start()
    {
        // Obtener el componente AudioSource del objeto
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Verificar si el tiempo en escala es diferente de cero y si la tecla Control no está presionada
        if (Time.timeScale != 0f && !Input.GetKey(KeyCode.LeftControl))
        {
            // Detectar el clic del jugador para encender o apagar la linterna
            if (Input.GetButtonDown("Fire1")) // Puedes cambiar "Fire1" al botón que desees
            {
                if (encendida)
                {
                    ApagarLinterna();
                }
                else
                {
                    EncenderLinterna();
                }
            }
        }
    }

    void EncenderLinterna()
    {
        luz.enabled = true; // Encender la luz
        encendida = true; // Actualizar el estado
        ReproducirSonido(encenderSound); // Reproducir sonido de encendido
    }

    void ApagarLinterna()
    {
        luz.enabled = false; // Apagar la luz
        encendida = false; // Actualizar el estado
        ReproducirSonido(apagarSound); // Reproducir sonido de apagado
    }

    void ReproducirSonido(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
