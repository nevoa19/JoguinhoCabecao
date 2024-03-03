using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rg;
    private CharacterController controller;
    private Animator anim;

    public float speed;
    public float gravity;
    public float rotSpeed;

    private float rot;
    private Vector3 moveDirection;

    public AudioSource run;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = transform.forward * speed;
                anim.SetInteger("transition", 1);
                run.Play();
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetInteger("transition", 2);
            }
            
             if (Input.GetKeyUp(KeyCode.Q))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        //moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
    if(collision.collider.name.Contains("maxuel")){
        GameController.instance.GameOver();
        anim.SetInteger("transition", 2);
    }
}
    
}

