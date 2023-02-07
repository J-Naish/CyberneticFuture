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

    
    void Start()
    {
        // 持続時間を設定
        duration = 7.0f;


        this.gameObject.GetComponent<MechaSuperHelmet>().enabled = false;


        // メカ使用時のPlayerのライフ
        playerCurrentLife = player.GetComponent<Player1Controller>().currentLife;

        // Playerの最大ライフ
        playerGrossLife = player.GetComponent<Player1Controller>().grossLife;

        // Playerの最大ライフと現在ライフの差
        lifeDecrease = playerGrossLife - playerCurrentLife;

    }

    
    void Update()
    {

        currentTime += Time.deltaTime;


        // 一定時間ライフが減らない
        // 一旦ライフを満タンにしてライフを一定にする
        if(currentTime < duration)
        {

            player.GetComponent<Player1Controller>().currentLife = playerGrossLife;

        }
        // 持続時間が終わればライフを元に
        if(currentTime == duration)
        {

            player.GetComponent<Player1Controller>().currentLife -= lifeDecrease;

        }

    }


}