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
    private bool isAlreadyBoosted = false;
    private bool isAlreadyDeboosted = false;


    // メカ使用を検知するためのオブジェクト取得
    [SerializeField] private GameObject mechaUse;



    private void Start()
    {
        //持続時間を定義
        duration = 5.0f;
    }


    private void Update()
    {
        SuperShoesUsed();
    }



    private void SuperShoesUsed()
    {
        // Prefabが新規生成された時のみ実行
        if (!isPrefabGenerated) return;

        // メカの使用を検知した時のみ実行
        if (!mechaUse.GetComponent<MechaUse>().useMecha) return;
        

        // カウント開始
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
        if (currentTime >= duration)
        {
            // 一度だけ処理を起こす
            if (!isAlreadyDeboosted)
            {
                player.GetComponent<Player1Controller>().moveVelocity /= boostVelocity;

                // 処理を起こしたのでbool値を元に戻す
                isAlreadyDeboosted = true;
            }

            // 使用後はuseMechaをfalseに戻す
            // メカ効果時間経過後に戻すためにバグが起きるかも
            mechaUse.GetComponent<MechaUse>().useMecha = false;


            // 使用後はisPrefabGeneratedをfalseに戻す
            isPrefabGenerated = false;

            // メカ使用後はプレファブ化されたものを破壊
            Destroy(this.gameObject);
        }

    }



}