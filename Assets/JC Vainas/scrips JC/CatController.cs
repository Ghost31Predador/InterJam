using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CatController : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotationSpeed = 0.15F;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtiene la direcci�n de movimiento basada en la entrada del usuario
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Si hay alguna entrada del usuario, actualiza la direcci�n de movimiento
        if (inputDirection.magnitude > 0.1f)
        {
            // Calcula la direcci�n a la que debe mirar el gato
            Quaternion toRotation = Quaternion.LookRotation(inputDirection, Vector3.up);

            // Suaviza la rotaci�n del gato hacia esa direcci�n
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Mueve el gato en la direcci�n en que est� mirando
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
    }
}


