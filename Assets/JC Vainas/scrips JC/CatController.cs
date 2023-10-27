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
        // Obtiene la dirección de movimiento basada en la entrada del usuario
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Si hay alguna entrada del usuario, actualiza la dirección de movimiento
        if (inputDirection.magnitude > 0.1f)
        {
            // Calcula la dirección a la que debe mirar el gato
            Quaternion toRotation = Quaternion.LookRotation(inputDirection, Vector3.up);

            // Suaviza la rotación del gato hacia esa dirección
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Mueve el gato en la dirección en que está mirando
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
    }
}


