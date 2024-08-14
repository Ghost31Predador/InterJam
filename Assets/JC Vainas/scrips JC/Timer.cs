using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float gameTime = 60f;        // Duración del temporizador en segundos
    public TextMeshProUGUI timerText;   // Componente TextMeshProUGUI para mostrar el tiempo
    public GameObject endGameUI;        // El panel de UI que se mostrará al final del juego

    private bool isGameOver = false;    // Estado del juego

    void Start()
    {
        // Asegúrate de que el componente TextMeshProUGUI esté asignado en el Inspector
        if (timerText == null)
        {
            Debug.LogError("TimerText no está asignado en el inspector.");
        }
        if (endGameUI == null)
        {
            Debug.LogError("EndGameUI no está asignado en el inspector.");
        }
        endGameUI.SetActive(false); // Asegúrate de que la UI de fin de juego esté oculta al inicio
    }

    void Update()
    {
        if (isGameOver)
            return; // No hacer nada si el juego ya terminó

        // Reduce el tiempo
        gameTime -= Time.deltaTime;

        // Convierte el tiempo restante a un entero y actualiza el texto del temporizador
        timerText.text = "Timer: " + Mathf.CeilToInt(Mathf.Clamp(gameTime, 0, Mathf.Infinity)).ToString() + "s";

        // Si el tiempo se acaba, cambia a la pantalla de fin del juego
        if (gameTime <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameOver = true; // Marca el juego como terminado
        endGameUI.SetActive(true); // Muestra la UI de fin de juego

        // Deshabilita el movimiento del jugador
        // Asume que tienes un componente de movimiento en el jugador llamado "CharacterControl"
        CharacterControl playerControl = GetComponent<CharacterControl>();
        if (playerControl != null)
        {
            playerControl.enabled = false;
        }
    }

    public void RestartGame()
    {
        // Cargar la escena de inicio del juego o reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}