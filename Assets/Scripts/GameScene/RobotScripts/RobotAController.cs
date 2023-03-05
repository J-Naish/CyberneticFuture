using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAController : RobotBase
{


    // ミニマップ用のCubeを取得
    [SerializeField] private GameObject minimapCube;



    void Start()
    {
        // ロボットのライフを設定
        robotGrossLife = 200.0f;

        // ロボットが受け渡すエナジーを設定
        robotEnergy = 250.0f;

        SetRobotLife();

        // 経験値を定義
        expPoint = 40;

    }



    void Update()
    {
        BarChange();

        BreakWhenDeath();
    }



}
