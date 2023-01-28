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
        // Player1のステータス
        moveVelocity = 10.0f;
        grossLife = 1000.0f;
        grossEnergy = 1000.0f;


        characterController = GetComponent<CharacterController>();


    }


    void Update()
    {

        animator.SetFloat("MoveSpeed", moveDirection.magnitude); // とりあえず数値で


        // キャラクターの移動
        // 1/n 暫定的に十字キーで移動
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
