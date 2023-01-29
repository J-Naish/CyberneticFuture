using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player1Controller : BasePlayer
{

    // アニメーション用変数
    [SerializeField] private Animator animator;

    // キャラクター移動用変数
    private CharacterController characterController;
    private Vector3 moveDirection;


    // ライフ表示UI
    [SerializeField] private GameObject LifeBar;
    private Slider lifeSlider;


    void Start()
    {
        // Player1のステータス
        moveVelocity = 10.0f;
        grossLife = 1000.0f;
        currentLife = grossLife;
        grossEnergy = 1000.0f;
        currentEnergy = grossEnergy;


        // キャラクターコントローラー取得
        characterController = GetComponent<CharacterController>();


        // スライダーの設定
        lifeSlider = LifeBar.transform.Find("Slider").GetComponent<Slider>();
        lifeSlider.value = 1f;


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
