using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 敵の弾発射に関するクラス
public class EnemyBulletController : MonoBehaviour
{

    // 弾丸と速度を取得
    [SerializeField] private GameObject bullet;
    private float bulletSpeed = 10000.0f;


    // 弾丸を撃つ消費エナジーを取得
    private float bulletRequiringEnergy = 60.0f;


    // エナジーを消費するためにEnemyを取得
    [SerializeField] private GameObject enemy;


    // 時間を計測するための変数
    private float currentTime = 0f;



    void Update()
    {
        // とりあえず2秒おきに弾を発射
        WaitSecondsForShoot(2.0f);

    }



    // Enemyを弾を発射するcoroutine
    private void ShootBullet()
    {

        // 一定距離にいる時だけ
        if (enemy.GetComponent<EnemyMove>().distance <= 20.0f)
        {
            // 必要エナジーがある時だけ
            if (enemy.GetComponent<EnemyController>().currentEnergy >= bulletRequiringEnergy)
            {
                // 弾丸をPrefab化
                GameObject Bullet =
                    Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));

                // 弾丸に力を加える
                Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

                // エナジーを消費
                enemy.GetComponent<EnemyController>().currentEnergy -= bulletRequiringEnergy;

                // 弾丸を一定時間後に破壊
                Destroy(Bullet, 3.0f);
            }
        }

    }


    // n秒後に弾を発射する関数
    private void WaitSecondsForShoot(float n)
    {

        currentTime += Time.deltaTime;

        // n秒経てば弾を撃つ
        if(currentTime >= n)
        {
            // 弾を発射する
            ShootBullet();

            // 時間をリセット
            currentTime = 0f;

        }

    }


}
