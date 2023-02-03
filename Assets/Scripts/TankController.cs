using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{


    // タンクのエナジー容量
    private float maxEnergyCapacity;
    // タンクに注入されたエナジー量
    public float currentTankEnergy;

    // エナジー表示UI
    [SerializeField] private GameObject EnergyBar;
    private Slider energySlider;


    private void Start()
    {

        // タンクの最大容量を800に設定(暫定)
        maxEnergyCapacity = 800.0f;

        // 最初のエナジー量は0
        currentTankEnergy = 0f;


        // スライダーの設定
        energySlider = EnergyBar.transform.Find("Slider").GetComponent<Slider>();
        energySlider.value = 1f;

    }



    private void Update()
    {

        // エナジー量UIを変更する関数
        EnergyBarChange();

        // エナジーが満タンになれば破壊
        if(currentTankEnergy >= maxEnergyCapacity)
        {

            Destroy(this.gameObject);
            

        }





    }


    // エナジー量に応じてUIを変える関数
    private void EnergyBarChange()
    {
        energySlider.value = (float)currentTankEnergy / (float)maxEnergyCapacity;
    }



}
