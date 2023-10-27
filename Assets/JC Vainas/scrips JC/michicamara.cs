using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class michicamara : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir� (el gato)
    public Vector3 offset; // La distancia entre la c�mara y el gato

    void Update()
    {
        // Mueve la c�mara a la posici�n del gato m�s el desplazamiento
        transform.position = target.position + offset;

        // Aseg�rate de que la c�mara siempre est� mirando al gato
        transform.LookAt(target);
    }
}
