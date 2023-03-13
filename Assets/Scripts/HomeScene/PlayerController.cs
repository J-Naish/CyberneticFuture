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
        MoveByKey();
    }


    // キーで移動させる関数
    private void MoveByKey()
    {
        // animatorのパラメーターを定義
        animator.SetFloat("MoveSpeed", moveDirection.magnitude);


        // キャラクターの移動
        // *暫定的に十字キーで移動
        if (Input.GetKeyDown(KeyCode.F))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            moveDirection += transform.right;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            moveDirection -= transform.right;
        }
        // キーの入力がなければ移動量は0に
        if (!Input.anyKey)
        {
            moveDirection = Vector3.zero;
        }

        // ベクトルを正規化
        moveDirection.Normalize();

        // 移動方向に向く
        transform.LookAt(transform.position + moveDirection);

        // 移動させる
        characterController.Move(moveDirection * moveVelocity * Time.deltaTime);

    }



}
