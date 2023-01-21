using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{

    /// <summary>
    /// ライフの総量
    /// </summary>
    protected float grossLife;

    /// <summary>
    /// エナジーの総量
    /// </summary>
    protected float grossEnergy;


    /// <summary>
    /// 移動速度の係数
    /// </summary>
    protected float moveVelocity;


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
    /// 最新の位置
    /// </summary>
    protected Vector3 latestPosition;



    // キャラの移動のメソッド
    // 暫定的に矢印キーで移動
    protected void MoveByArrowKey()
    {

        // 移動ベクトルを取得
        Vector3 diff = transform.position - latestPosition;


        // 上矢印キーで前進
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * moveVelocity;
        }

        // 下矢印キーで後進
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * moveVelocity;
        }

        // 右矢印キーで右に
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * moveVelocity;
        }

        // 左矢印キーで左に
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * moveVelocity;
        }


        // 向いている向きを修正
        transform.rotation = Quaternion.LookRotation(diff, Vector3.up);


        // 最新の位置を更新
        latestPosition = transform.position;

    }

}
