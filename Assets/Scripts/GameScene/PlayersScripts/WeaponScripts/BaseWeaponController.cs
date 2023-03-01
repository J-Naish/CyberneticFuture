using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 武器に関する共通基底クラス
public class BaseWeaponController : MonoBehaviour
{
    // Playerを取得
    [SerializeField] protected GameObject player;

    // 消費エナジーに関する変数
    protected float requiringEnergy;


    // 必殺技が溜まるまでの時間
    protected float superPowerCoolTime;


    // 必殺技ボタンを取得
    [SerializeField] protected GameObject superPowerButton;


    // 時間を計測するための変数
    protected float currentTime;


    // 武器を使用する関数
    protected virtual void UseWeapon()
    {
    }


    // 武器の種類に応じてPlayerのステータスを決定する関数
    protected void SetStatus(float life, float energy, float speed, int superPowerLevel)
    {
        // Playerのステータスを決定
        player.GetComponent<Player1Controller>().grossLife = life;
        player.GetComponent<Player1Controller>().grossEnergy = energy;
        player.GetComponent<Player1Controller>().moveVelocity = speed;
        player.GetComponent<Player1Controller>().superPowerRequringLevel = superPowerLevel;
    }


    // 必殺技が溜まってるかどうかのbool値変更
    protected void SuperPowerCharged()
    {
        if(player.GetComponent<Player1Controller>().playerLevel
            < player.GetComponent<Player1Controller>().superPowerRequringLevel)
        {
            return;
        }

        if (currentTime >= superPowerCoolTime)
        {
            // bool値変更
            superPowerButton.GetComponent<SuperPowerButton>().isSuperPowerCharged = true;
        }
    }


    protected void SuperPowerUsed()
    {
        // bool値をfalseに
        superPowerButton.GetComponent<SuperPowerButton>().isSuperPowerCharged = false;
        // 時間をリセット
        currentTime = 0;
    }


}
