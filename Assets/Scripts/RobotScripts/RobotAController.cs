using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAController : RobotBase
{


    
    void Start()
    {
        // ロボットのライフを設定
        robotGrossLife = 200.0f;


        SetRobotLife();

    }

    
    void Update()
    {
        BarChange();
    }


}
