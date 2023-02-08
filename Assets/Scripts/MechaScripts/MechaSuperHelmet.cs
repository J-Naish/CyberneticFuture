using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーが一定時間無敵になるメカ
public class MechaSuperHelmet : MechaBase
{

    // Playerを取得
    [SerializeField] private GameObject player;

    // Playerの現在ライフを取得
    private float playerCurrentLife;

    // Playerの最大ライフを取得
    private float playerGrossLife;

    // Playerの最大ライフと現在ライフの差
    private float lifeDecrease;


    // メカ使用を検知するためのオブジェクト取得
    [SerializeField] private GameObject mechaUse;


    void Start()
    {
        // 持続時間を設定
        duration = 7.0f;



        // メカ使用時のPlayerのライフ
        playerCurrentLife = player.GetComponent<Player1Controller>().currentLife;

        // Playerの最大ライフ
        playerGrossLife = player.GetComponent<Player1Controller>().grossLife;

        // Playerの最大ライフと現在ライフの差
        lifeDecrease = playerGrossLife - playerCurrentLife;

    }

    
    void Update()
    {


        if (mechaUse.GetComponent<MechaUse>().useMecha)
        {

            // カウント開始
            currentTime += Time.deltaTime;


            // 一定時間ライフが減らない
            // 一旦ライフを満タンにしてライフを一定にする
            if (currentTime < duration)
            {
                // ライフを満タンのままキープ
                player.GetComponent<Player1Controller>().currentLife = playerGrossLife;

            }
            // 持続時間が終わればライフを元に
            if (currentTime == duration)
            {
                // ライフをメカ使用前に戻す
                player.GetComponent<Player1Controller>().currentLife -= lifeDecrease;

                // 使用後はuseMechaをfalseに戻す
                mechaUse.GetComponent<MechaUse>().useMecha = false;

                // メカ使用後はプレファブ化されたものを破壊
                Destroy(this.gameObject);
            }

        }

    }


}