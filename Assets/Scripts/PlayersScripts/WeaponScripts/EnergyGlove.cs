using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// エナジーグローブに関するクラス
public class EnergyGlove : BaseWeaponController
{


    void Start()
    {

        // ステータスを設定
        SetStatus(1700.0f,500.0f, 17.0f);

        // 消費エナジーを設定
        requiringEnergy = 3.0f;

    }

    
    void Update()
    {
        GloveAttack();
    }


    // グローブで攻撃する関数
    private void GloveAttack()
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
