using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAController : RobotBase
{

    // ダメージ
    private float damage;

    // 攻撃してきたもののタグを取得
    private string colliderTag;

    // Playerを取得
    private GameObject playerObject;

    // ミニマップ用のCubeを取得
    [SerializeField] private GameObject minimapCube;


    // 経験値を定義
    [SerializeField] private int expPoint = 40;



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
            TransferEnergyToKiller();

            // 経験値を受け渡す
            TransferExpPointToKiller();

            // ダメージ処理
            robotCurrentLife -= damage;
        }
    }


    // キルされたらエナジーを受け渡す関数
    private void TransferEnergyToKiller()
    {
        // ダメージが現在ライフを超えた時のみ
        if(damage >= robotCurrentLife)
        {
            if(colliderTag == "PlayerWeapon")
            {
                // キルしたものの情報を取得
                minimapCube.GetComponent<RobotMiniMapCube>().killerIsPlayer = true;

                playerObject.GetComponent<Player1Controller>().currentEnergy += robotEnergy;
            }
            else if(colliderTag == "EnemyWeapon")
            {
                // キルしたものの情報を取得
                minimapCube.GetComponent<RobotMiniMapCube>().killerIsEnemy = true;

                playerObject.GetComponent<EnemyController>().currentEnergy += robotEnergy;
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
