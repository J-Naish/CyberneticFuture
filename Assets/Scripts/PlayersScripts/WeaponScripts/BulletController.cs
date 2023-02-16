using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BaseWeaponController
{

    // 弾丸と弾丸速度を宣言
    public GameObject bullet;
    public float bulletSpeed;


    // 必殺技の弾丸と速度を取得
    [SerializeField] private GameObject superBullet;
    private float superBulletSpeed = 7000.0f;


    private void Awake()
    {
        // ステータスを設定
        SetStatus(900.0f, 1100.0f, 10.0f);

    }


    void Start()
    {
        // 消費エナジーを設定
        requiringEnergy = 40.0f;

        // 必殺技が溜まる時間を定義
        superPowerCoolTime = 40.0f;

    }




    void Update()
    {
        // 時間計測
        currentTime += Time.deltaTime;

        // 通常攻撃
        BulletAttack();

        // 必殺技
        BulletSuperPower();

        // bool値変更関数
        SuperPowerCharged();

        // エイムする関数
        AimForward();
    }


    private void BulletAttack()
    {

        // 必要エナジーがある時だけ呼び出す
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

                // Prefab化した弾丸を破壊
                Destroy(Bullet, 3.0f);
            }

        }

    }


    private void BulletSuperPower()
    {
        // 必殺技が溜まってたら使用できる
        if (superPowerButton.GetComponent<SuperPowerButton>().isSuperPowerCharged)
        {

            // Sキーで使える
            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject SuperBullet =
                    Instantiate(superBullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                SuperBullet.GetComponent<BulletCollisionController>().damage = 200.0f;

                Rigidbody superBulletRb = SuperBullet.GetComponent<Rigidbody>();
                superBulletRb.AddForce(transform.forward * superBulletSpeed);

                // 必殺技を使用した判定をする関数
                SuperPowerUsed();

                // Prefab化した弾丸を破壊
                Destroy(SuperBullet, 3.0f);
            }

        }

    }


    // エイミングする関数
    private void AimForward()
    {

        // Aキーを押してる間エイムモーションに
        if (Input.GetKey(KeyCode.A))
        {
            // Aimトリガーを起動
            player.GetComponent<Player1Controller>().animator.SetTrigger("Aim");
        }


    }



}