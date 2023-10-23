using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ControladorPersonaje : MonoBehaviour
{

    
    private CharacterController characterController;
    private Vector3 escalaInicial;
    public float factorCrecimiento = 0.2f;
    public int objyum = 0;
    private int contador = 0;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        escalaInicial = transform.localScale;
    }

    // Este método se llama cuando el Character Controller colisiona con otro Collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

       

        // Verifica si la colisión involucra un objeto con una etiqueta específica
        if (hit.collider.CompareTag("destruible"))
        {
            // Realiza acciones específicas cuando colisiona con un objeto con la etiqueta "ObjetoColision"
            // Por ejemplo, puedes destruir el objeto colisionado:
            Vector3 TObj = hit.collider.bounds.size;

            Vector3 Tgato = characterController.bounds.size;

            if (TObj.x < Tgato.x && TObj.y < Tgato.y && TObj.z < Tgato.z)
            {
                Destroy(hit.collider.gameObject);
                if (objyum == contador)
                {


                    if (contador <= 50)
                    {

                        contador += 20;
                        Debug.Log("suma 20 al contador");
                        transform.localScale *= factorCrecimiento;
                    }
                    else if (contador <= 150)
                    {

                        contador += 25;
                        Debug.Log("suma 25 al contador");
                        transform.localScale *= factorCrecimiento;
                    }
                    else if (contador <= 300)
                    {
                        contador += 50;
                        Debug.Log("suma 50 al contador");
                        transform.localScale *= factorCrecimiento;
                    }
                    else
                    {
                        contador += 100;
                        Debug.Log("suma 100 al contador");
                        transform.localScale *= factorCrecimiento;
                    }
                    objyum -= objyum;
                }

                objyum += 1;
                Debug.Log("comio obj");

                
            }
        }
        
    }
 
}
