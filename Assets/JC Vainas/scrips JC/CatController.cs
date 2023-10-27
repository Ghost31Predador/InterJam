using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class CatController : MonoBehaviour
{
    public Camera cam; // La c�mara que est�s usando
    public float speed = 3.0F;
    public float rotationSpeed = 0.15F;
    private CharacterController controller;
    public Animator animator;
    private float Vsprint = 1;
    private Vector3 velocity; // La velocidad actual del gato
    public float gravity = -9.81f; // La gravedad que quieres aplicar

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Si el gato no est� en el suelo, aplica la gravedad
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Si el gato est� en el suelo, resetea la velocidad vertical
            velocity.y = 0;
        }

        // Aplica la velocidad al gato
        controller.Move(velocity * Time.deltaTime);

        //seccion de animaciones 

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("hit", true);
        }
        else
        {
            animator.SetBool("hit", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vsprint = 4;
            animator.SetBool("correr", true);
        }
        else
        {
            animator.SetBool("correr", false);
            Vsprint = 1;
        }

        // Obtiene la direcci�n de movimiento basada en la entrada del usuario
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Si hay alguna entrada del usuario, actualiza la direcci�n de movimiento
        if (inputDirection.magnitude > 0.1f)
        {
            //animacion de movimiento
            animator.SetFloat("move", 1);
            // Calcula la direcci�n a la que debe mirar el gato bas�ndose en la rotaci�n de la c�mara
            Quaternion toRotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
            Vector3 direction = toRotation * inputDirection;

            // Suaviza la rotaci�n del gato hacia esa direcci�n
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            // Mueve el gato en la direcci�n en que est� mirando
            controller.Move(direction * (speed * Vsprint) * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("move", 0);
        }

    }
}
