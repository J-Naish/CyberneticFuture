using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{


    // タンクのエナジー容量
    private float maxEnergyCapacity;
    // タンクに注入されたエナジー量
    private float currentTankEnergy;


    private void Start()
    {

        // タンクの最大容量を800に設定(暫定)
        maxEnergyCapacity = 800.0f;

        // 最初のエナジー量は0
        currentTankEnergy = 0f;


    }



}
