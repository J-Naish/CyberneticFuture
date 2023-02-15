using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ライトセーバーに関するクラス
public class SwordController : BaseWeaponController
{
    
    void Start()
    {
        // Playerのステータスを設定
        SetStatus(1400.0f, 700.0f, 14.0f);

        // 消費エナジー量を設定
        requiringEnergy = 10.0f;
    }


    private void Update()
    {
        SwordAttack();
    }


    // 剣で攻撃する関数
    private void SwordAttack()
    {
        // Enterで攻撃
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 剣を振るアニメーションを起動
            player.GetComponent<Player1Controller>().animator.SetTrigger("SwordAttack");

            // エナジーを消費
            player.GetComponent<Player1Controller>().currentEnergy -= requiringEnergy;
        }
    }

}
