using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ライトセーバーに関するクラス
public class SwordController : BaseWeaponController
{



    private void Awake()
    {
        // Playerのステータスを設定
        SetStatus(1400.0f, 700.0f, 14.0f,8);

        // 武器の種類を定義
        isCollisionWeapon = true;
    }


    void Start()
    {
        // 消費エナジー量を設定
        requiringEnergy = 10.0f;

        // 必殺技が溜まる時間を定義
        superPowerCoolTime = 90.0f;

        // ダメージを定義
        damage = 80.0f;
    }


    private void Update()
    {
        // 時間計測開始
        currentTime += Time.deltaTime;

        // 通常攻撃
        SwordAttack();

        // 必殺技
        SwordSuperPower();

        // bool値変更関数
        SuperPowerCharged();
    }


    // 剣で攻撃する関数
    private void SwordAttack()
    {
        // エナジーが十分ある時だけ攻撃できる
        if (player.GetComponent<Player1Controller>().currentEnergy >= requiringEnergy)
        {

            // Enterで攻撃
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // 剣を振るアニメーションを起動
                player.GetComponent<Player1Controller>().animator.SetTrigger("SwordAttack");

                // エナジーを消費
                player.GetComponent<Player1Controller>().currentEnergy -= requiringEnergy;

                // SEを起動するbool値を変更
                GetComponent<EnergySwordSE>().isAttacking = true;
            }

        }
    }


    // 必殺技(モーションは通常攻撃と同じ)
    private void SwordSuperPower()
    {
        // 必殺技が溜まってたら発動できる
        if (superPowerButton.GetComponent<SuperPowerButton>().isSuperPowerCharged)
        {

            // Sで必殺技使用
            if (Input.GetKeyDown(KeyCode.P))
            {
                // 通常攻撃と同じアニメーションを流用
                player.GetComponent<Player1Controller>().animator.SetTrigger("SwordAttack");

                // 必殺技を使用した判定をする関数
                SuperPowerUsed();
            }

        }

    }

    

}
