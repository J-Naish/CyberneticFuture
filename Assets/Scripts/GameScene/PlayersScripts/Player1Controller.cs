using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player1Controller : BasePlayer
{

    // アニメーション用変数
    [SerializeField] public Animator animator;


    // ライフ表示UI
    [SerializeField] private GameObject LifeBar;
    private Slider lifeSlider;

    // エナジー表示UI
    [SerializeField] private GameObject EnergyBar;
    private Slider energySlider;


    // 敵を取得
    [SerializeField] private GameObject enemy;


    // ダメージを宣言
    private float damage;


    // CharacterControllerを取得
    private CharacterController characterController;

    // 移動に用いる変数
    private Vector3 moveDirection;




    void Start()
    {
        // Player1のステータス
        currentLife = grossLife;
        currentEnergy = grossEnergy;


        // スライダーの設定

        // ライフ
        lifeSlider = LifeBar.transform.Find("Slider").GetComponent<Slider>();
        lifeSlider.value = 1f;

        // エナジー
        energySlider = EnergyBar.transform.Find("Slider").GetComponent<Slider>();
        energySlider.value = 1f;


        // CharacterControllerを取得
        characterController = GetComponent<CharacterController>();

    }


    void Update()
    {
        // エナジーバーを変化
        EnergyBarChange();

        // エナジーが上限を超えないように
        NotExcessGrossEnergy();

        // キャラが移動する関数
        MoveByKey();
    }



    // エナジーバー変更の関数
    private void EnergyBarChange()
    {
        energySlider.value = (float)currentEnergy / (float)grossEnergy;
        lifeSlider.value = (float)currentLife / (float)grossLife;
    }



    // 弾が当たったらダメージが減る処理
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突対象が弾の時のみ
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            Debug.Log("Hit");

            // damageを定義
            damage = collision.gameObject.GetComponent<DamageController>().damage;

            // エナジーを受け渡す
            TransferEnergyToKiller();

            currentLife -= damage;
        }

    }



    // デスしたら相手にエナジーを渡す関数
    private void TransferEnergyToKiller()
    {
        // ダメージ量が現在ライフを超えてる時だけ渡す
        if (currentLife <= damage)
        {
            // エナジーを受け渡す
            enemy.GetComponent<EnemyController>().currentEnergy += this.currentEnergy;

        }

    }





    // 十字キーで移動する関数
    private void MoveByKey()
    {
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

        if (!Input.anyKey)
        {
            moveDirection = Vector3.zero;
        }

        moveDirection.Normalize();

        transform.LookAt(transform.position + moveDirection);

        characterController.Move(moveDirection * moveVelocity * Time.deltaTime);
    }


}
