using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// HomeSceneでのプレイヤーを操作するクラス
public class PlayerController : MonoBehaviour
{

    // アニメーション用変数
    [SerializeField] private Animator animator;


    // キャラクター移動用変数
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float moveVelocity = 50.0f;





    void Start()
    {

        // キャラクターコントローラー取得
        characterController = GetComponent<CharacterController>();



    }

    
    void Update()
    {

        MoveByArrowKey();

    }



    private void MoveByArrowKey()
    {


        animator.SetFloat("MoveSpeed", moveDirection.magnitude);


        // キャラクターの移動
        // *暫定的に十字キーで移動
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
