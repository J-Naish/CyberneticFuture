using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// エナジーグローブに関するクラス
public class EnergyGlove : BaseWeaponController
{

    private void Awake()
    {
        // ステータスを設定
        SetStatus(1700.0f, 500.0f, 17.0f,8);

        // 武器の種類を定義
        isCollisionWeapon = true;

    }


    void Start()
    {
        // 消費エナジーを設定
        requiringEnergy = 3.0f;

        // 必殺技が溜まる時間を定義
        superPowerCoolTime = 100.0f;

        // ダメージを定義
        damage = 110;

    }


    void Update()
    {
        // 時間計測開始
        currentTime += Time.deltaTime;

        // 通常攻撃
        GloveAttack();

        // 必殺技
        GloveSuperPower();

        // bool値変更関数
        SuperPowerCharged();
    }



    // グローブで攻撃する関数
    private void GloveAttack()
    {
        // エナジーが十分ある時だけ攻撃できる
        if (player.GetComponent<Player1Controller>().currentEnergy >= requiringEnergy)
        {

            // Enterで攻撃
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // 剣を振るアニメーションと同じアニメーションを流用
                player.GetComponent<Player1Controller>().animator.SetTrigger("SwordAttack");

                // エナジーを消費
                player.GetComponent<Player1Controller>().currentEnergy -= requiringEnergy;
            }

        }
    }


    // 必殺技(モーションは通常攻撃と同じ)
    private void GloveSuperPower()
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
