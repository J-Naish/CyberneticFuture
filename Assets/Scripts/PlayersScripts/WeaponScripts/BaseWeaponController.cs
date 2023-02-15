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


    // 武器を使用する関数
    protected virtual void UseWeapon()
    {
    }


    // 武器の種類に応じてPlayerのステータスを決定する関数
    protected void SetStatus(float life,float energy,float speed)
    {
        // Playerのステータスを決定
        player.GetComponent<Player1Controller>().grossLife = life;
        player.GetComponent<Player1Controller>().grossEnergy = energy;
        player.GetComponent<Player1Controller>().moveVelocity = speed;

    }


}
