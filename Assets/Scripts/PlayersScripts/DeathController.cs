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


    protected void Start()
    {
        // スタート地点の位置を取得
        startPoint = startPointObject.transform.position;

    }


    protected virtual void Update()
    {
        // 5秒後に復活するように設定
        ReviveAtStartPointAfterSeconds(5.0f);

    }


    // スタート地点に戻るcoroutine
    protected virtual void ReviveAtStartPointAfterSeconds(float n)
    {
        // ライフが0になると処理開始
        if (player.GetComponent<Player1Controller>().currentLife <= 0)
        {
            // 秒数カウント開始
            currentTime += Time.deltaTime;

            // スタート地点に強制転移
            player.transform.position = startPoint;

            // Playerオブジェクトを非アクティブに
            player.SetActive(false);


            // n秒経てばライフとエナジーをMAXに
            if (currentTime >= n)
            {
                // Playerをアクテイブに戻す
                player.SetActive(true);

                // エナジーとライフをMAXに
                player.GetComponent<Player1Controller>().currentLife = player.GetComponent<Player1Controller>().grossLife;
                player.GetComponent<Player1Controller>().currentEnergy = player.GetComponent<Player1Controller>().grossEnergy;

            }

        }

    }




}
