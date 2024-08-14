using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;                    // Variable para almacenar el puntaje
    public TextMeshProUGUI scoreText;        // Componente TextMeshProUGUI para mostrar el puntaje

    void Start()
    {
        // Asegúrate de que el componente TextMeshProUGUI esté asignado en el Inspector
        if (scoreText == null)
        {
            Debug.LogError("ScoreText no está asignado en el inspector.");
        }
        UpdateScoreText(); // Inicializar el texto del puntaje
    }

    // Método público para sumar puntaje
    public void AddScore(int points)
    {
        score += points;       // Sumar puntos al puntaje
        UpdateScoreText();     // Actualizar el texto del puntaje
    }

    // Método privado para actualizar el texto del puntaje en la UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Mostrar el puntaje en el TextMeshPro
    }
}
