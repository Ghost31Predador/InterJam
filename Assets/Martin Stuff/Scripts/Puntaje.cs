using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Puntaje : MonoBehaviour
{
    private float puntos;

    public TextMeshProUGUI textMesh; 
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); 
    }

    private void Update()
    {
        puntos += Time.deltaTime;
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
