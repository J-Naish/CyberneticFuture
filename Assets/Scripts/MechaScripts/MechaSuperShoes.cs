using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// playerの移動速度を上げるメカ
public class MechaSuperShoes : MechaBase
{

    // 移動速度上昇率
    private float boostValue = 2.0f;

    // Playerを取得
    [SerializeField] private GameObject player;


    private void Start()
    {

        //持続時間を設定
        duration = 10.0f;

    }


    private void Update()
    {

        currentTime += Time.deltaTime;

        // 一定時間移動速度上昇
        if(currentTime < duration)
        {

            player.GetComponent<Player1Controller>().moveVelocity *= boostValue;

        }

    }



}
