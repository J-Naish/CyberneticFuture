using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player1Controller : BasePlayer
{

    [SerializeField] private Animator animator;

    private CharacterController characterController;
    private Vector3 moveDirection;


    void Start()
    {
        moveVelocity = 10.0f;
        characterController = GetComponent<CharacterController>();
    }
    

    void Update()
    {

        animator.SetFloat("MoveSpeed",0.1f); // direction.magnitudeでやりたいけどできないからとりあえず数値で


        // キャラクターの移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection += transform.right;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection -= transform.right;
        }

        if (!Input.anyKey)
        {
            moveDirection = Vector3.zero;
        }

        moveDirection.Normalize();

        transform.LookAt(transform.position + moveDirection);

        characterController.Move(moveDirection * moveVelocity * Time.deltaTime);


    }


}
