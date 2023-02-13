using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{

    /// <summary>
    /// ライフの総量
    /// </summary>
    public float grossLife;


    /// <summary>
    /// 現在のライフ
    /// </summary>
    public float currentLife;


    /// <summary>
    /// エナジーの総量
    /// </summary>
    public float grossEnergy;


    /// <summary>
    /// 現在のエナジー
    /// </summary>
    public float currentEnergy;


    /// <summary>
    /// 移動速度の係数
    /// </summary>
    public float moveVelocity;


    /// <summary>
    /// 回転の速度
    /// </summary>
    protected float rotationSpeed;


    /// <summary>
    /// 攻撃力
    /// </summary>
    protected float attackPoint;


    /// <summary>
    /// 攻撃してから次の攻撃ができるまでにかかる時間
    /// </summary>
    protected float attackSpeed;


    /// <summary>
    /// 防御力
    /// </summary>
    protected float defensePoint;


    /// <summary>
    /// 必殺技が溜まるまでの時間
    /// </summary>
    protected int superPowerCoolTime;


    /// <summary>
    /// プレイヤーのレベル
    /// </summary>
    protected int playerLevel;



    // エナジーが上限を超えないようにする関数
    protected void NotExcessGrossEnergy()
    {

        if(currentEnergy > grossEnergy)
        {
            currentEnergy = grossEnergy;
        }

    }


}