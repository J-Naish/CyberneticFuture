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


    // 移動処理に用いる変数
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;



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


        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {

        GetInputAxis();

        // エナジーバーを変化
        EnergyBarChange();

        // エナジーが上限を超えないように
        NotExcessGrossEnergy();

    }


    private void FixedUpdate()
    {
        MoveByArrowKey();
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



    // 入力を取得する関数
    private void GetInputAxis()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }




    // 十字キーで移動する関数
    private void MoveByArrowKey()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveVelocity + new Vector3(0, rb.velocity.y, 0);

        // アニメーションのパラメーターを設定
        animator.SetFloat("MoveSpeed", moveForward.magnitude);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }


}
