using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// playerの移動速度を上げるメカ
public class MechaSuperShoes : MechaBase
{

    // 移動速度上昇率
    private float boostVelocity = 3.0f;

    // Playerを取得
    [SerializeField] private GameObject player;


    // 処理を一度だけ起こすためのbool値
    private bool isAlreadyBoosted;
    private bool isAlreadyDeboosted;


    private void Start()
    {

        this.gameObject.GetComponent<MechaSuperShoes>().enabled = false;

        // 初期はfalseとして設定
        isAlreadyBoosted = false;
        isAlreadyDeboosted = false;



        //持続時間を設定
        duration = 10.0f;

    }


    private void Update()
    {


        currentTime += Time.deltaTime;

        // 一定時間移動速度上昇
        if (currentTime < duration)
        {
            // 一度だけ処理を起こす
            if (!isAlreadyBoosted)
            {
                player.GetComponent<Player1Controller>().moveVelocity *= boostVelocity;

                // 処理を起こしたのでbool値を元に戻す
                isAlreadyBoosted = true;
            }

        }
        //  速度を元に戻す
        if(currentTime >=  duration)
        {
            // 一度だけ処理を起こす
            if (!isAlreadyDeboosted)
            {
                player.GetComponent<Player1Controller>().moveVelocity /= boostVelocity;

                // 処理を起こしたのでbool値を元に戻す
                isAlreadyDeboosted = true;
            }

        }

    }



}