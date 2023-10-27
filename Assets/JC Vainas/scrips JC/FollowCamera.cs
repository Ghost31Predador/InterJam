using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir� (el gato)
    public Vector3 offset; // La distancia base entre la c�mara y el gato
    public float scaleFactor = 1.0f; // El factor por el cual se ajustar� la distancia de la c�mara
    public float rotationSpeed = 100.0f; // La velocidad de rotaci�n de la c�mara

    private float currentY = 0.0f;

    void Start()
    {
        // Atrapa y oculta el cursor del mouse cuando comienza el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Calcula el desplazamiento actual basado en el tama�o del gato
        Vector3 currentOffset = offset * (target.localScale.x * scaleFactor);

        // Mueve la c�mara a la posici�n del gato m�s el desplazamiento actual
        transform.position = target.position + currentOffset;

        // Aseg�rate de que la c�mara siempre est� mirando al gato
        transform.LookAt(target);

        // Obtiene la entrada del mouse
        currentY += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Rota la c�mara alrededor del gato basado en la entrada del mouse
        transform.RotateAround(target.position, Vector3.up, currentY);
    }
}

