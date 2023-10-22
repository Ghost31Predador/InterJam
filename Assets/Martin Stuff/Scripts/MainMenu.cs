using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CambiarEscena(string name)
    {
        SceneManager.LoadScene("BigCity");
    }
    public void FuncionCerrarJuego()
    {
        Application.Quit(); 
    }

    public void Regresar(string name) 
    {
        SceneManager.LoadScene("Main Menu");
    }
}
