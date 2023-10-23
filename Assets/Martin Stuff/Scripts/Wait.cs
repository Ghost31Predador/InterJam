using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(EsperarTiempo());
    }

    IEnumerator EsperarTiempo()
    {
        Debug.Log("Inicio de la espera");
        yield return new WaitForSeconds(126);
        SceneManager.LoadScene(1); 
    }
}
