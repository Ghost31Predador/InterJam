using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class michicamara : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (el gato)
    public Vector3 offset; // La distancia entre la cámara y el gato

    void Update()
    {
        // Mueve la cámara a la posición del gato más el desplazamiento
        transform.position = target.position + offset;

        // Asegúrate de que la cámara siempre esté mirando al gato
        transform.LookAt(target);
    }
}
