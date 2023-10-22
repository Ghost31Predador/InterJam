using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject botomPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject opciones;
    public void Pause()
    {
        Time.timeScale = 0; 
        botomPausa.SetActive(false);
        menuPausa.SetActive(true);
        print("Funciona"); 
    }

    public void Continue()
    {
        Time.timeScale = 1;
        botomPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Opciones()
    {
        Time.timeScale = 0; 
        botomPausa.SetActive(false); 
        menuPausa.SetActive(false);
        opciones.SetActive(true);
    }
    
    public void Regresar()
    {
        Time.timeScale = 0;
        botomPausa.SetActive(false);
        menuPausa.SetActive(true);
        opciones.SetActive(false);
    }
}
