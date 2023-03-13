using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キングロボットがジャンプする関数
public class KingRobotJump : MonoBehaviour
{

    // Rigidbodyを取得
    private Rigidbody rb;

    // ジャンプの係数を宣言
    private float jumpPower = 7.0f;


    // キングロボットのライフを参照するためのゲームオブジェクト
    [SerializeField] private GameObject kingRobotController;
    private float kingRobotCurrentLife;

    // 時間変数
    private float currentTime = 0f;
    private float spanJump = 3.0f;



    private void Start()
    {
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        // ロボットの現在ライフを取得
        kingRobotCurrentLife = kingRobotController.GetComponent<KingRobotController>().robotCurrentLife;

        JumpUp();
    }


    // ジャンプする関数
    private void JumpUp()
    {
        // ライフが半分以下になった時だけ
        if (kingRobotCurrentLife <= kingRobotController.GetComponent<KingRobotController>().robotGrossLife / 2)
        {
            // 時間を計測
            currentTime += Time.deltaTime;

            if (currentTime >= spanJump)
            {
                // ジャンプ
                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);

                // 時間をリセット
                currentTime = 0f;
            }
        }
    }


}
