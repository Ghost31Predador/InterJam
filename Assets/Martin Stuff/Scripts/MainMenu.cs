using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene(2);
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