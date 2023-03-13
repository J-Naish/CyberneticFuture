using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Tankに関するクラス
public class TankController : MonoBehaviour
{


    // タンクのエナジー容量
    [SerializeField] public float maxEnergyCapacity;
    // タンクに注入されたエナジー量
    public float currentTankEnergy;

    // エナジー表示UI
    [SerializeField] private GameObject EnergyBar;
    private Slider energySlider;


    private void Start()
    {
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

    }


    // エナジー量に応じてUIを変える関数
    private void EnergyBarChange()
    {
        energySlider.value = (float)currentTankEnergy / (float)maxEnergyCapacity;
    }



}
