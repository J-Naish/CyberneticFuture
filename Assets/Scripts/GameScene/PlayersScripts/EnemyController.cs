using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 敵(bot)に関するクラス
public class EnemyController : BasePlayer
{

    // ライフ表示UI
    [SerializeField] private GameObject LifeBar;
    private Slider lifeSlider;

    // エナジー表示UI
    [SerializeField] private GameObject EnergyBar;
    private Slider energySlider;


    // Playerを取得
    [SerializeField] private GameObject player;


    void Start()
    {

        // とりあえずライフの最大を1000に設定
        grossLife = 1000.0f;
        currentLife = grossLife;


        // エナジーの設定
        grossEnergy = 1000.0f;
        currentEnergy = grossEnergy;


        // スライダーの設定

        // ライフ
        lifeSlider = LifeBar.transform.Find("Slider").GetComponent<Slider>();
        lifeSlider.value = 1f;

        // エナジー
        energySlider = EnergyBar.transform.Find("Slider").GetComponent<Slider>();
        energySlider.value = 1f; // エナジー消費処理を書く時に値を更新するコードが必要


        // 継承した変数を定義
        playerLevel = 1;
        maxLevel = 15;
        grossExpPoint = 0;
        expCoefficient = 80;

    }


    void Update()
    {
        SliderChangeByValue();

        DontExcessGrossEnergyAndLife();

        LevelUp();
        StatusIncreaseByLevel();
    }


    // バーを更新する関数
    private void SliderChangeByValue()
    {
        // ライフゲージ処理
        lifeSlider.value = (float)currentLife / (float)grossLife;

        // エナジーバーを更新する処理
        energySlider.value = (float)currentEnergy / (float)grossEnergy;

    }



}
