using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // 弾丸と弾丸速度を宣言
    public GameObject bullet;
    public float bulletSpeed;

    // 弾丸の消費エナジー
    private float bulletRequiringEnergy;


    // playerのエナジー消費のためにplayerを取得
    private GameObject player;
    // private float energy;



    void Start()
    {

        // とりあえずエナジーを40消費する
        bulletRequiringEnergy = 40.0f;

        // Player1を取得
        player = GameObject.Find("Player1");

        // energyに代入すると値が謎に0になるのでコメントアウト
        // energy = player.GetComponent<Player1Controller>().grossEnergy;


    }




    void Update()
    {


        // 必要エナジーがある時だけ呼び出す
        if (player.GetComponent<Player1Controller>().grossEnergy >= bulletRequiringEnergy)
        {

            if (Input.GetKeyDown(KeyCode.Return)) // 2/n 暫定的にエンターボタンで発射
            {
                GameObject Bullet =
                    Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * bulletSpeed);

                // エナジーを消費
                player.GetComponent<Player1Controller>().grossEnergy -= bulletRequiringEnergy;
                // 確認用
                Debug.Log(player.GetComponent<Player1Controller>().grossEnergy);

                Destroy(Bullet, 3.0f);
            }

        }


    }
}