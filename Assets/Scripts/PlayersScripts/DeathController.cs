using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// デスに関するクラス
public class DeathController : MonoBehaviour
{

    // スタート地点の位置を取得するための変数
    [SerializeField] protected GameObject startPointObject;
    protected Vector3 startPoint;

    // プレイヤーを取得
    [SerializeField] protected GameObject player;

    // 数秒待って復活するための時間に関する変数
    protected float currentTime = 0f;


    // デスして復活までの時間
    public float deathTime = 5.0f;

    // Playerのライフが0になった事を検知するbool
    public bool isUnder0Life = false;


    protected void Start()
    {
        // スタート地点の位置を取得
        startPoint = startPointObject.transform.position;

    }


    protected virtual void Update()
    {
        // 5秒後に復活するように設定
        ReviveAtStartPointAfterSeconds(deathTime);
        // デスを検知する関数
        IsLifeOver0OrNot();
    }


    // スタート地点に戻るcoroutine
    protected virtual void ReviveAtStartPointAfterSeconds(float n)
    {
        // ライフが0になると処理開始
        if (isUnder0Life)
        {
            // 秒数カウント開始
            currentTime += Time.deltaTime;


            // スタート地点に強制転移
            player.transform.position = startPoint;


            // Playerオブジェクトを非アクティブに
            player.SetActive(false);


            // エナジーとライフをMAXに
            player.GetComponent<Player1Controller>().currentLife = player.GetComponent<Player1Controller>().grossLife;
            player.GetComponent<Player1Controller>().currentEnergy = player.GetComponent<Player1Controller>().grossEnergy;


            // n秒経てば復活
            if (currentTime >= n)
            {
                // Playerをアクテイブに戻す
                player.SetActive(true);

                // ライフ0以下を検知するboolを更新
                isUnder0Life = false;
            }

        }

    }


    // Playerのライフが0以下になった事を検知する関数
    private void IsLifeOver0OrNot()
    {
        if(player.GetComponent<Player1Controller>().currentLife <= 0)
        {
            isUnder0Life = true;
        }
    }




}
