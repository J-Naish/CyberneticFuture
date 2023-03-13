using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


// キングロボットに関するクラス
public class KingRobotController : RobotBase
{

    void Start()
    {
        // ロボットの初期設定
        robotGrossLife = 50000.0f;
        robotEnergy = 400.0f;

        SetRobotLife();

        expPoint = 300;

    }

    
    void Update()
    {
        BarChange();

        BreakWhenDeath();
    }

}
