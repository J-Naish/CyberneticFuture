using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingRobotController : RobotBase
{

    // 倒したチームのタグを取得
    private string killerTeamTag;

    // ダメージを格納する変数
    private float damage;

    // 衝突したオブジェクトのタグ
    private string colliderTag;


    
    void Start()
    {
        // ロボットの初期設定
        robotGrossLife = 3000.0f;
        robotEnergy = 400.0f;

        SetRobotLife();

    }

    
    void Update()
    {
        BarChange();

        BreakWhenDeath();
    }



    // ダメージを受ける処理
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerWeapon") || other.CompareTag("EnemyWeapon"))
        {

            // 衝突対象の情報を取得
            colliderTag = other.tag;


            // ダメージを取得
            this.damage = other.gameObject.GetComponent<DamageController>().damage;

            // デスした場合エナジーを受け渡す
            TransferEnergyToKillerTeam();

            // ダメージ処理
            robotCurrentLife -= damage;
        }
    }


    // キルされたらエナジーを受け渡す関数
    private void TransferEnergyToKillerTeam()
    {
        // ダメージが現在ライフを超えた時のみ
        if (damage >= robotCurrentLife)
        {
            if (colliderTag == "PlayerWeapon")
            {
                // タグがPlayerのオブジェクトを全て取得
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                // それぞれにエナジーを追加
                foreach(GameObject playerObject in players)
                {
                    playerObject.GetComponent<Player1Controller>().currentEnergy += robotEnergy;
                }
            }
            else if (colliderTag == "EnemyWeapon")
            {
                // タグがEnemyのオブジェクトを全て取得
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                // それぞれにエナジーを追加
                foreach (GameObject enemyObject in enemies)
                {
                    enemyObject.GetComponent<Player1Controller>().currentEnergy += robotEnergy;
                }
            }


        }
    }


}
