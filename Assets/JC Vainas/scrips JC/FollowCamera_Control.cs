using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera_Control : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (el gato)
    public Vector3 offset; // La distancia base entre la cámara y el gato
    public float scaleFactor = 1.0f; // El factor por el cual se ajustará la distancia de la cámara
    public float rotationSpeed = 100.0f; // La velocidad de rotación de la cámara

    private float currentY = 0.0f;
    private Vector2 lookInput; // Vector2 para almacenar la entrada del joystick derecho

    void Start()
    {
        // Atrapa y oculta el cursor del mouse cuando comienza el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Calcula el desplazamiento actual basado en el tamaño del gato
        Vector3 currentOffset = offset * (target.localScale.x * scaleFactor);

        // Mueve la cámara a la posición del gato más el desplazamiento actual
        transform.position = target.position + currentOffset;

        // Asegúrate de que la cámara siempre esté mirando al gato
        transform.LookAt(target);

        // Obtiene la entrada del joystick derecho
        lookInput = new Vector2(Input.GetAxis("RightStickHorizontal"), Input.GetAxis("RightStickVertical"));

        // Ajusta la rotación en función de la entrada del joystick derecho
        currentY += lookInput.x * rotationSpeed * Time.deltaTime;

        // Rota la cámara alrededor del gato basado en la entrada del joystick derecho
        transform.RotateAround(target.position, Vector3.up, currentY);
    }
}
