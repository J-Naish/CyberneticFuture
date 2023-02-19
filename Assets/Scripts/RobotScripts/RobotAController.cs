using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAController : RobotBase
{


    
    void Start()
    {
        // ロボットのライフを設定
        robotGrossLife = 200.0f;

        // ロボットが受け渡すエナジーを設定
        robotEnergy = 250.0f;

        SetRobotLife();

    }

    
    void Update()
    {
        BarChange();
    }


    // エナジーをキルしたPlayerに渡す
    private void OnTriggerEnter(Collider other)
    {
        // 武器で攻撃してきたplyerを取得
        player = other.transform.root.gameObject;

        if (player.CompareTag("Enemy"))
        {
            currentEnergyOfPlayer = player.GetComponent<EnemyController>().currentEnergy;
        }
        if (player.CompareTag("Player"))
        {
            currentEnergyOfPlayer = player.GetComponent<Player1Controller>().currentEnergy;
        }

    }


}
