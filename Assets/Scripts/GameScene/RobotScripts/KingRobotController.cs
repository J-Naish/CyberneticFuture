using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class KingRobotController : RobotBase
{

    // 倒したチームのタグを取得
    private string killerTeamTag;

    // ダメージを格納する変数
    private float damage;

    // 衝突したオブジェクトのタグ
    private string colliderTag;


    // Playerを取得
    private GameObject playerObject;


    // 経験値を定義
    [SerializeField] private int expPoint = 500;


    void Start()
    {
        // ロボットの初期設定
        robotGrossLife = 1500.0f;
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
            playerObject = other.transform.root.gameObject;


            // ダメージを取得
            this.damage = other.gameObject.GetComponent<DamageController>().damage;

            // デスした場合エナジーを受け渡す
            TransferEnergyToKillerTeam();

            // 経験値を受け渡す
            TransferExpPointToKiller();

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
                GameObject.FindWithTag("Player").GetComponent<Player1Controller>().currentEnergy += robotEnergy;


                // ※Debugで配列の中身確認
                //NullReference Errorとなるため一旦コメントアウト
                // タグがPlayerのオブジェクトを全て取得
                //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                //// それぞれにエナジーを追加
                //foreach (GameObject playerObject in players)
                //{
                //    playerObject.GetComponent<Player1Controller>().currentEnergy += robotEnergy;
                //}
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



    // キルされたら経験値を受け渡す関数
    private void TransferExpPointToKiller()
    {
        // ダメージが現在ライフを超えた時のみ
        if (damage >= robotCurrentLife)
        {
            if (colliderTag == "PlayerWeapon")
            {
                playerObject.GetComponent<Player1Controller>().grossExpPoint += expPoint;
            }
            else if (colliderTag == "EnemyWeapon")
            {
                playerObject.GetComponent<EnemyController>().grossExpPoint += expPoint;
            }
        }
    }


}
