using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キャラクターの基底クラス
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
    /// プレイヤーのレベル(1からスタート)
    /// </summary>
    public int playerLevel;


    /// <summary>
    /// レベルの上限
    /// </summary>
    protected int maxLevel;


    /// <summary>
    /// 獲得経験値の総量
    /// </summary>
    public int grossExpPoint;


    /// <summary>
    /// キャラをキルした時に得られる経験値の係数
    /// </summary>
    public int expCoefficient;


    /// <summary>
    /// 一度だけステータス上昇させるためのフラグ
    /// </summary>
    protected bool isLevelUp = false;


    /// <summary>
    /// 必殺技を覚えるのに必要なレベル
    /// </summary>
    public int superPowerRequringLevel;


    // レベルアップに応じたライフの上昇数
    protected float lifeIncreaseByLevelup = 100.0f;

    // レベルアップに応じたエナジーの上昇率
    protected int energyIncreaseByLevelup = 10;

    // レベルアップに応じた移動速度の上昇係数
    protected float velocityIncreaseByLevelip = 1.01f;



    /// <summary>
    /// エナジーとライフが上限を超えないようにする関数
    /// </summary>
    protected void DontExcessGrossEnergyAndLife()
    {
        // 上限を超えたら最大量にする
        if(currentEnergy > grossEnergy)
        {
            currentEnergy = grossEnergy;
        }

        if (currentLife > grossLife)
        {
            currentLife = grossLife;
        }
    }



    /// <summary>
    /// 経験値に応じてレベルを上げる関数
    /// </summary>
    protected void LevelUp()
    {
        // レベルの上限に達したらそれ以上レベルアップしない
        if (playerLevel == maxLevel) return;

        // 現在レベル×100の経験値でレベルアップ
        if(grossExpPoint >= playerLevel * 100)
        {
            // レベルアップ
            playerLevel += 1;
            // レベルアップを検知
            isLevelUp = true;
            // 経験値をリセット
            grossExpPoint = 0;
        }

    }



    /// <summary>
    /// レベルに応じてステータスを変更するクラス
    /// </summary>
    protected void StatusIncreaseByLevel()
    {
        // 処理を一度だけにするためのif文
        if (isLevelUp)
        {
            // レベルに応じて最大ライフを上昇
            grossLife += lifeIncreaseByLevelup;
            currentLife += lifeIncreaseByLevelup;

            // レベルに応じて最大エナジーを上昇
            grossEnergy += energyIncreaseByLevelup * (playerLevel - 1);
            currentEnergy += energyIncreaseByLevelup * (playerLevel - 1);

            // レベルに応じて移動速度を上昇
            moveVelocity *= Mathf.Pow(velocityIncreaseByLevelip, playerLevel - 1);


            // レベルアップ検知変数を更新
            isLevelUp = false;
        }

    }



}