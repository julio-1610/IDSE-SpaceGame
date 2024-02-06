using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    public GameOverScript GameOverScript;
    int maxPlatform = 0;
    public GameObject Nave;
    public GameObject panelVictoria;
    public Text PuntajeText;
    public float CombustibleMaximo = 100.0f;
    public Scrollbar BarraCombustible;
    public float LimiteInferior = -10.0f;
    public Color ColorCombustibleNormal = Color.green;
    public Color ColorCombustibleBajo = Color.red;
    public float DuracionCombustibleSegundos = 120.0f; // Duración deseada en segundos

    private int Puntaje;
    private float CombustibleActual;
    private bool juegoIniciado = false;
    public Button botonSiguienteNivel;
    public Text textoSiguienteNivel;
    private bool juegoGanado = false;

    void Start()
    {
        // Inicializar puntaje
        Puntaje = 5;
        ActualizarPuntajeUI();

        // Inicializar combustible
        CombustibleActual = CombustibleMaximo;

        panelVictoria.SetActive(false);
        botonSiguienteNivel.gameObject.SetActive(false);
        Time.timeScale = 0f;

    }

    void Update()
    {
        // Actualizar combustible basado en la velocidad de la nave
        float tasaDeConsumo = CombustibleMaximo / DuracionCombustibleSegundos;
        CombustibleActual -= Time.deltaTime * tasaDeConsumo;
        CombustibleActual = Mathf.Max(0, CombustibleActual);

        // Actualizar la barra de combustible
        BarraCombustible.size = CombustibleActual / CombustibleMaximo;

        // Cambiar color de la barra de combustible según su nivel
        BarraCombustible.image.color = Color.Lerp(ColorCombustibleBajo, ColorCombustibleNormal, BarraCombustible.size);

        if (!juegoIniciado)
        {
            // Esperar a que se presione Espacio para iniciar el juego
            if (Input.GetKeyDown(KeyCode.Space))
            {
                juegoIniciado = true;
                // Despausar el juego cuando inicia
                Time.timeScale = 1f;
            }
            else
            {
                // No actualizar nada hasta que se presiona Espacio
                return;
            }
        }

        if (CombustibleActual <= 0 || Nave.transform.position.y < LimiteInferior || Puntaje <= 0)
        {
            GameOver();
        }

        if (!juegoGanado && Time.timeSinceLevelLoad >= 40f && CombustibleActual >= 0 && Nave.transform.position.y > LimiteInferior && Puntaje >= 0)
        {
            Ganaste();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Rigidbody>() != null)
        {
            // Colisionó con un objeto que tiene un Rigidbody (y posiblemente un collider)
            PerderPuntaje();

            // Reproducir el sonido de choque
            ReproducirSonidoChoque();
        }

        if (collision.collider.CompareTag("Ground"))
        {
            // Colisionó con el suelo
            PerderPuntaje();

            // Reproducir el sonido de choque
            ReproducirSonidoChoque();
        }
    }

    private void ReproducirSonidoChoque()
    {
        // Obtener el componente AudioSource
        AudioSource audioSource = Nave.GetComponent<AudioSource>();

        // Verificar si el componente existe y no está reproduciendo actualmente
        if (audioSource != null && !audioSource.isPlaying)
        {
            // Reproducir el sonido de choque
            audioSource.Play();
        }
    }
    private void PerderPuntaje()
    {
        // Verificar si el puntaje es mayor que cero antes de disminuirlo
        if (Puntaje > 0)
        {
            Puntaje--;

            // Reducir tiempo de combustible
            ReducirTiempoCombustible();

            // Actualizar la UI de puntaje
            ActualizarPuntajeUI();
        }

        // Verificar si el puntaje llega a cero
        if (Puntaje <= 0)
        {
            // Si el puntaje llega a cero, mostrar la pantalla de Game Over
            GameOverScript.Setup(maxPlatform);
        }
    }

    private void ReducirTiempoCombustible()
    {
        float tiempoReducido = 12.0f; // Tiempo a reducir cuando se pierde puntaje
        CombustibleActual -= tiempoReducido;
        CombustibleActual = Mathf.Max(0, CombustibleActual);
    }

    private void ActualizarPuntajeUI()
    {
        PuntajeText.text = "Vida: " + Puntaje;
    }

    private void GameOver()
    {
        // Puedes agregar aquí la lógica para reiniciar el juego, mostrar un mensaje de game over, etc.
        GameOverScript.Setup(maxPlatform);
    }

    private void Ganaste()
    {
        // Activar el panel de victoria y el botón de siguiente nivel
        panelVictoria.SetActive(true);
        botonSiguienteNivel.gameObject.SetActive(true);
        Time.timeScale = 0f;  // Pausar el juego
        textoSiguienteNivel.text = "GANASTE"; 

        juegoGanado = true;  // Indicar que el juego ha sido ganado
    }

    // Método que se asigna al botón de "Siguiente Nivel" desde el Inspector de Unity
    public void IrAlSiguienteNivel()
    {
        // Aquí debes cargar la siguiente escena. Puedes usar SceneManager.LoadScene o la lógica que prefieras.
        SceneManager.LoadScene("nivel2");
    }
}
