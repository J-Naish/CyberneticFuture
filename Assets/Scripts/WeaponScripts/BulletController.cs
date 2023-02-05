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
    private float grossEnergy;
    private float currentEnergy;



    void Start()
    {

        // とりあえずエナジーを40消費する設定
        bulletRequiringEnergy = 40.0f;

        // Player1を取得
        player = GameObject.Find("Player1");


        // ※代入すると値が謎に0になる 2/2
        // currentEnergy = player.GetComponent<Player1Controller>().currentEnergy;


    }




    void Update()
    {




        // 必要エナジーがある時だけ呼び出す
        // できれば変数に代入して書きたい
        if (player.GetComponent<Player1Controller>().currentEnergy >= bulletRequiringEnergy)
        {

            if (Input.GetKeyDown(KeyCode.Return)) // 2/n 暫定的にエンターボタンで発射
            {
                GameObject Bullet =
                    Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * bulletSpeed);


                // エナジーを消費
                player.GetComponent<Player1Controller>().currentEnergy -= bulletRequiringEnergy;



                Destroy(Bullet, 3.0f);
            }

        }


    }
}