using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キングロボットの着地時にパーティクルを放出させるクラス
public class TouchGround : MonoBehaviour
{

    // パーティクルを取得
    [SerializeField] private GameObject particle;

    // パーティクルの発生場所
    [SerializeField] private GameObject particlePosition;

    // 着地したことを検知するbool値
    [SerializeField] private bool isTouchingGround;


    // 時間変数
    private float currentTime = 0f;


    private void Update()
    {
        // 時間計測開始
        currentTime += Time.deltaTime;

        // 初期にパーティクルが出ないようにする
        if(currentTime <= 1.0f)
        {
            isTouchingGround = false;
        }


        GenerateParticle();
    }



    // 着地したらパーティクルをPrefab化
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
    }


    // パーティクルを生成する関数
    private void GenerateParticle()
    {
        if (isTouchingGround)
        {
            Instantiate(particle, particlePosition.transform.position, Quaternion.Euler(-90, 0, 0));
            isTouchingGround = false;
        }
    }


}
