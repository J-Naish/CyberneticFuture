using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BaseWeaponController
{

    // 弾丸と弾丸速度を宣言
    public GameObject bullet;
    public float bulletSpeed;



    // playerのエナジー消費のためにplayerを取得
    private float grossEnergy;
    private float currentEnergy;



    private void Awake()
    {
        // ステータスを設定
        SetStatus(900.0f, 1100.0f, 10.0f);

    }


    void Start()
    {
        // とりあえずエナジーを40消費する設定
        requiringEnergy = 40.0f;

    }




    void Update()
    {




        // 必要エナジーがある時だけ呼び出す
        // できれば変数に代入して書きたい
        if (player.GetComponent<Player1Controller>().currentEnergy >= requiringEnergy)
        {

            if (Input.GetKeyDown(KeyCode.Return)) // 2/n 暫定的にエンターボタンで発射
            {
                GameObject Bullet =
                    Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * bulletSpeed);


                // エナジーを消費
                player.GetComponent<Player1Controller>().currentEnergy -= requiringEnergy;



                Destroy(Bullet, 3.0f);
            }

        }


    }
}