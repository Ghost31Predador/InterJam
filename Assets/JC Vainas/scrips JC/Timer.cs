using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float gameTime = 60f;        // Duración del temporizador en segundos
    public TextMeshProUGUI timerText;   // Componente TextMeshProUGUI para mostrar el tiempo

    void Start()
    {
        // Asegúrate de que el componente TextMeshProUGUI esté asignado en el Inspector
        if (timerText == null)
        {
            Debug.LogError("TimerText no está asignado en el inspector.");
        }
    }

    void Update()
    {
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
        // Cargar la escena de fin del juego
        SceneManager.LoadScene("Main Menu"); // Cambia "Main Menu" por el nombre de tu escena
    }
}
