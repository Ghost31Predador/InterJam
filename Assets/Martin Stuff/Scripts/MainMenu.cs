using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CambiarEscena()
    {
<<<<<<< Updated upstream
        SceneManager.LoadScene(2);
=======
        SceneManager.LoadScene("BigCity");
>>>>>>> Stashed changes
    }
    public void FuncionCerrarJuego()
    {
        Application.Quit(); 
    }

    public void Regresar() 
    {
        SceneManager.LoadScene(0);
    }
}