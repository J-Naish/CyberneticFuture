using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    // Player1のチームが勝利したかどうか
    private bool isWinner;


    // タンクのエナジーを集計するための変数
    public float currentLeftTotalEnergy;
    public float currentRightTotalEnergy;

    


    void Start()
    {

        // 0からスタート
        currentLeftTotalEnergy = 0f;
        currentRightTotalEnergy = 0f;


    }

    
    void Update()
    {
        
    }
}
