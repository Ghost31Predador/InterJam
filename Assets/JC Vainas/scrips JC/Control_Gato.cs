using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Control_Gato : MonoBehaviour
{
    public Camera cam; // La cámara que estás usando
    public float speed = 3.0F;
    public float rotationSpeed = 0.15F;
    private CharacterController controller;
    public Animator animator;
    private float Vsprint = 1;
    private Vector3 velocity; // La velocidad actual del gato
    public float gravity = -9.81f; // La gravedad que quieres aplicar
    private Vector3 inputDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Sección de animaciones
        if (Input.GetKey(KeyCode.JoystickButton2)) // Botón 2 para golpear
        {
            animator.SetBool("hit", true);
        }
        else
        {
            animator.SetBool("hit", false);
        }

        if (Input.GetKey(KeyCode.JoystickButton4)) // Botón 4 para sprint
        {
            Vsprint = 4;
            animator.SetBool("correr", true);
        }
        else
        {
            animator.SetBool("correr", false);
            Vsprint = 1;
        }

        // Movimiento con la palanca izquierda del control
        inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        // Aplica la gravedad si no está en el suelo
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Resetea la velocidad vertical al tocar el suelo
            velocity.y = 0;
        }

        // Aplica la velocidad vertical acumulada al gato
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