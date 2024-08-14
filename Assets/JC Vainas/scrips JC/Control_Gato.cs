using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterControl : MonoBehaviour
{
    public Camera cam; // La cámara que estás usando
    public float speed = 3.0F;
    public float rotationSpeed = 0.15F;
    public float stickSensitivity = 2.0F; // Sensibilidad del stick izquierdo
    private CharacterController controller;
    public Animator animator;
    private float Vsprint = 1;
    private Vector3 velocity; // La velocidad actual del gato
    public float gravity = -9.81f; // La gravedad que quieres aplicar
    private Vector3 inputDirection;
    private Vector2 lookDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Sección de animaciones 
        if (Input.GetKeyDown(KeyCode.JoystickButton7)) // R2 para pegar
        {
            animator.SetBool("hit", true);
        }
        else
        {
            animator.SetBool("hit", false);
        }

        if (Input.GetKey(KeyCode.JoystickButton6)) // L2 para sprint
        {
            Vsprint = 4;
            animator.SetBool("correr", true);
        }
        else
        {
            animator.SetBool("correr", false);
            Vsprint = 1;
        }

        // Movimiento con la palanca izquierda con sensibilidad aumentada
        inputDirection = new Vector3(Input.GetAxis("Horizontal") * stickSensitivity, 0, Input.GetAxis("Vertical") * stickSensitivity);

    }

    private void FixedUpdate()
    {
        // Si el gato no está en el suelo, aplica la gravedad
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Si el gato está en el suelo, resetea la velocidad vertical
            velocity.y = 0;
        }

        // Aplica la velocidad al gato
        controller.Move(velocity * Time.deltaTime);

        // Si hay alguna entrada del usuario, actualiza la dirección de movimiento
        if (inputDirection.magnitude > 0.1f)
        {
            // Animación de movimiento
            animator.SetFloat("move", 1);

            // Calcula la dirección a la que debe mirar el gato basándose en la rotación de la cámara
            Quaternion toRotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
            Vector3 direction = toRotation * inputDirection;

            // Suaviza la rotación del gato hacia esa dirección
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            // Mueve el gato en la dirección en que está mirando
            controller.Move(direction * (speed * Vsprint) * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("move", 0);
        }
    }
}