using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    // Player1のチームが勝利したかどうか
    private string winningTeam;


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
        SaveWinnerData();
    }



    // どちらのチームが勝ってるか文字列として格納
    private void SaveWinnerData()
    {
        if(currentLeftTotalEnergy > currentRightTotalEnergy)
        {
            winningTeam = "Left";
        }
        if(currentLeftTotalEnergy < currentRightTotalEnergy)
        {
            winningTeam = "Right";
        }
        if(currentLeftTotalEnergy == currentRightTotalEnergy)
        {
            winningTeam = "Draw";
        }
    }



}
