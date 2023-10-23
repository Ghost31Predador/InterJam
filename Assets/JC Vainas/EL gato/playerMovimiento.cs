using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovimiento : MonoBehaviour
{
        private CharacterController characterController;
    public new Transform camera;
    public float speed = 4;
    public float gravity = -9.8f;
    public int Vsprint = 1;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;


        if (hor !=0 || ver != 0)
        {
            animator.SetFloat("move", 1);


            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();


           Vector3 direction = forward * ver + right * hor;

            direction.Normalize();

            
            movement = direction * (speed * Vsprint) * Time.deltaTime;

           transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),0.02f );
        }
        else
        {
            animator.SetFloat("move", 0);

        }

        movement.y += gravity * Time.deltaTime;
        characterController.Move(movement);

    }
}
