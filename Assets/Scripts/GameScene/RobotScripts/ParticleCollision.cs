using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// パーティクルが衝突した時の処理に関するクラス
public class ParticleCollision : MonoBehaviour
{

    // ダメージを定義
    private float damage = 50.0f;


    // 時間変数を定義
    private float currentTime = 0f;

    // 衝突を検知するbool値
    private bool isCollidered;


    // 一定時間衝突処理させないための時間
    private float colliderPreventingTime = 3.0f;



    private void Update()
    {
        DontColliderMoreThanOnce();
    }



    // パーティクルの衝突処理
    private void OnParticleCollision(GameObject other)
    {

        // パーティクルの１つが衝突してしばらくは同じ処理をさせない
        if (currentTime > 0) return;


        if (other.CompareTag("Player"))
        {
            // ダメージを与える
            other.GetComponent<Player1Controller>().currentLife -= damage;

            // アニメーションを起動
            other.GetComponent<Player1Controller>().animator.SetTrigger("Hindered");

            // 衝突を検知
            isCollidered = true;
        }
    }



    // 複数回衝突処理をさせないようにする関数
    private void DontColliderMoreThanOnce()
    {
        // 衝突したら時間計測開始
        if (isCollidered)
        {
            currentTime += Time.deltaTime;
        }

        // 一定時間経過したら衝突処理をできるようにする
        if (currentTime > colliderPreventingTime)
        {
            // 衝突検知変数を更新
            isCollidered = false;

            // 時間をリセット
            currentTime = 0f;
        }
    }



}
