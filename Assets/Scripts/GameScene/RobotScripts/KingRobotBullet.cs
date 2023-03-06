using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キングロボットの攻撃に関するクラス
public class KingRobotBullet : MonoBehaviour
{

    // 弾丸のゲームオブジェクトを取得
    [SerializeField] private GameObject bullet;

    // 弾丸を放つスパン
    [SerializeField] private float shootSpan = 2.0f;


    // 弾丸のスピード
    [SerializeField] private float bulletSpeed = 5000.0f;


    // 範囲内にいるかを検知するために取得するオブジェクト
    [SerializeField] private GameObject kingRobot;


    // 間隔を空けて弾を撃つための変数
    private float currentTime = 0f;


    void Update()
    {
        // shootSpan秒おきに弾丸を発射
        ShootingBulletAfterSeconds(shootSpan);

    }



    // 弾丸を発射する関数
    private void ShootBullet()
    {
        // 弾丸をPrefab化
        GameObject Bullet =
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));

        // 弾丸を飛ばす
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        // 弾丸を一定時間後に破壊
        Destroy(Bullet, 3.0f);

    }


    // 弾丸をt秒おきに発射する関数
    private void ShootingBulletAfterSeconds(float t)
    {
        // 範囲内にいる時のみ処理を行う
        if (kingRobot.GetComponent<KingRobotMove>().playerIsInArea)
        {
            // 時間計測開始
            currentTime += Time.deltaTime;

            // t秒経過したら
            if (currentTime >= t)
            {
                ShootBullet();
                currentTime = 0f;
            }
        }

    }
}
