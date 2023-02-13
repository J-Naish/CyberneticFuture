using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Enemyのデスに関するクラス
// Playerのデスに関するクラスを継承
public class EnemyDeathController : DeathController
{


    protected override void Update()
    {
        ReviveAtStartPointAfterSeconds(5.0f);
    }


    protected override void ReviveAtStartPointAfterSeconds(float n)
    {
        // ライフが0になると処理開始
        if (player.GetComponent<EnemyController>().currentLife <= 0)
        {
            // 秒数カウント開始
            currentTime += Time.deltaTime;

            // スタート地点に強制転移
            player.transform.position = startPoint;

            // Playerを非アクティブに
            player.SetActive(false);


            // n秒経てばライフとエナジーをMAXに
            if (currentTime >= n)
            {

                // Playerをアクテイブに戻す
                player.SetActive(true);

                // エナジーとライフをMAXに
                player.GetComponent<EnemyController>().currentLife = player.GetComponent<EnemyController>().grossLife;
                player.GetComponent<EnemyController>().currentEnergy = player.GetComponent<EnemyController>().grossEnergy;

            }

        }
    }


}
