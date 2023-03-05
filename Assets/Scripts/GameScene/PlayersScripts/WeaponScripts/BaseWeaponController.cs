using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 武器に関する共通基底クラス
public class BaseWeaponController : MonoBehaviour
{
    // Playerを取得
    [SerializeField] protected GameObject player;

    // 消費エナジーに関する変数
    protected float requiringEnergy;


    // 必殺技が溜まるまでの時間
    protected float superPowerCoolTime;


    // 必殺技ボタンを取得
    [SerializeField] protected GameObject superPowerButton;


    // 時間を計測するための変数
    protected float currentTime;

    // ダメージを定義
    protected float damage;

    // 近接系の武器かどうかのbool値
    protected bool isCollisionWeapon;

    // 弾丸系の武器かどうかのbool値
    protected bool isBullet;



    // 武器の種類に応じてPlayerのステータスを決定する関数
    protected void SetStatus(float life, float energy, float speed, int superPowerLevel)
    {
        // Playerのステータスを決定
        player.GetComponent<Player1Controller>().grossLife = life;
        player.GetComponent<Player1Controller>().grossEnergy = energy;
        player.GetComponent<Player1Controller>().moveVelocity = speed;
        player.GetComponent<Player1Controller>().superPowerRequringLevel = superPowerLevel;
    }


    // 必殺技が溜まってるかどうかのbool値変更
    protected void SuperPowerCharged()
    {
        if(player.GetComponent<Player1Controller>().playerLevel
            < player.GetComponent<Player1Controller>().superPowerRequringLevel)
        {
            return;
        }

        if (currentTime >= superPowerCoolTime)
        {
            // bool値変更
            superPowerButton.GetComponent<SuperPowerButton>().isSuperPowerCharged = true;
        }
    }


    protected void SuperPowerUsed()
    {
        // bool値をfalseに
        superPowerButton.GetComponent<SuperPowerButton>().isSuperPowerCharged = false;
        // 時間をリセット
        currentTime = 0;
    }



    // ダメージ処理
    protected void OnTriggerEnter(Collider other)
    {
        // 近接系以外の武器(飛び道具など)は別の処理方法で行う
        if (!isCollisionWeapon) return;

        // 衝突対象が装備者なら処理を行わない
        if (other.gameObject == transform.root.gameObject) return;


        if (other.CompareTag("Player"))
        {
            // ダメージが現在ライフを超えてる時の処理
            // エナジーと経験値を渡す
            if (other.gameObject.GetComponent<Player1Controller>().currentLife <= damage)
            {
                // エナジーを取得
                player.GetComponent<Player1Controller>().currentEnergy +=
                    other.gameObject.GetComponent<Player1Controller>().currentEnergy;

                // 経験値を取得
                player.GetComponent<Player1Controller>().grossExpPoint +=
                    other.gameObject.GetComponent<Player1Controller>().playerLevel * other.gameObject.GetComponent<Player1Controller>().expCoefficient;
            }

            // ライフにダメージを与える
            other.gameObject.GetComponent<Player1Controller>().currentLife -= damage;

            // 弾丸系の武器の場合は衝突処理後に破壊
            if (isBullet) Destroy(this.gameObject);

        }
        else if (other.CompareTag("Enemy"))
        {
            // ダメージが現在ライフを超えてる時の処理
            // エナジーと経験値を渡す
            if (other.gameObject.GetComponent<EnemyController>().currentLife <= damage)
            {
                // エナジーを取得
                transform.root.gameObject.GetComponent<Player1Controller>().currentEnergy +=
                    other.gameObject.GetComponent<EnemyController>().currentEnergy;

                // 経験値を取得
                transform.root.gameObject.GetComponent<Player1Controller>().grossExpPoint +=
                    other.gameObject.GetComponent<EnemyController>().playerLevel *
                    other.gameObject.GetComponent<Player1Controller>().expCoefficient;
            }

            // ライフにダメージを与える
            other.gameObject.GetComponent<EnemyController>().currentLife -= damage;

            // 弾丸系の武器の場合は衝突処理後に破壊
            if (isBullet) Destroy(this.gameObject);

        }
        else if (other.CompareTag("Robot"))
        {
            // ダメージが現在ライフを超えてる時の処理
            // エナジーと経験値を渡す
            if (other.gameObject.GetComponent<RobotAController>().robotCurrentLife <= damage)
            {
                // エナジーを取得
                transform.root.gameObject.GetComponent<Player1Controller>().currentEnergy +=
                    other.gameObject.GetComponent<RobotAController>().robotEnergy;

                // 経験値を取得
                transform.root.gameObject.GetComponent<Player1Controller>().grossExpPoint +=
                    other.gameObject.GetComponent<RobotAController>().expPoint;
            }

            // ライフにダメージを与える
            other.gameObject.GetComponent<RobotAController>().robotCurrentLife -= damage;

            // 弾丸系の武器の場合は衝突処理後に破壊
            if (isBullet) Destroy(this.gameObject);

        }
        else if (other.CompareTag("KingRobot"))
        {
            // ダメージが現在ライフを超えてる時の処理
            // エナジーと経験値を渡す
            if (other.gameObject.GetComponent<KingRobotController>().robotCurrentLife <= damage)
            {
                // 味方全員がエナジーを取得
                GameObject.FindWithTag("Player").GetComponent<Player1Controller>().currentEnergy +=
                    other.gameObject.GetComponent<KingRobotController>().robotEnergy;

                //NullReference Errorとなるため一旦コメントアウト
                // タグがPlayerのオブジェクトを全て取得
                //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                //// それぞれにエナジーを追加
                //foreach (GameObject playerObject in players)
                //{
                //    playerObject.GetComponent<Player1Controller>().currentEnergy += robotEnergy;
                //}

                // 味方全体が経験値を取得
                GameObject.FindWithTag("Player").GetComponent<Player1Controller>().grossExpPoint +=
                    other.gameObject.GetComponent<KingRobotController>().expPoint;
            }

            // ライフにダメージを与える
            other.gameObject.GetComponent<KingRobotController>().robotCurrentLife -= damage;

            // 弾丸系の武器の場合は衝突処理後に破壊
            if (isBullet) Destroy(this.gameObject);

        }
        // その他のものに衝突した場合
        else
        {
            // 弾丸系の武器の場合は衝突処理後に破壊
            if (isBullet) Destroy(this.gameObject);

        }
    }



}
