using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// playerの移動速度を上げるメカ
public class MechaSuperShoes : MechaBase
{

    // 移動速度上昇率
    private float boostedVelocity = 2.0f;

    // Playerを取得
    [SerializeField] private GameObject player;


    // Playerの元の速度
    private float originalMoveVelocity;

    // 処理を一度だけ起こすためのbool値
    private bool isAlreadyBoosted;


    private void Start()
    {

        this.gameObject.GetComponent<MechaSuperShoes>().enabled = false;

        // 初期はfalseとして設定
        isAlreadyBoosted = false;

        // Playerの本来の移動速度係数を取得
        originalMoveVelocity = player.GetComponent<Player1Controller>().moveVelocity;

        //持続時間を設定
        duration = 10.0f;

    }


    private void Update()
    {

        currentTime += Time.deltaTime;

        // 一定時間移動速度上昇
        if (currentTime < duration)
        {
            if (!isAlreadyBoosted)
            {
                player.GetComponent<Player1Controller>().moveVelocity *= boostedVelocity;

                // 処理を起こしたのでbool値を元に戻す
                isAlreadyBoosted = true;
            }

        }
        if(currentTime >= duration)
        {
            player.GetComponent<Player1Controller>().moveVelocity = originalMoveVelocity;
        }

    }



}