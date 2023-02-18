using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : BasePlayer
{

    // 敵の武器とそのダメージ
    private float damage;
    private GameObject weapon;

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



    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerWeapon"))
        {
            // ダメージを取得
            weapon = other.gameObject;
            damage = weapon.GetComponent<BulletCollisionController>().damage;

            TransferEnergyToKiller();

            currentLife -= damage;

            // 衝突対象を破壊(剣などの場合は残す処理は必要)
            Destroy(weapon);
        }

    }


    void Update()
    {
        EnergyBarChange();

        NotExcessGrossEnergy();
    }


    // バーを更新する関数
    private void EnergyBarChange()
    {
        // ライフゲージ処理
        lifeSlider.value = (float)currentLife / (float)grossLife;

        // エナジーバーを更新する処理
        energySlider.value = (float)currentEnergy / (float)grossEnergy;

    }


    // デスしたら相手にエナジーを渡す関数
    private void TransferEnergyToKiller()
    {
        // ダメージ量が現在ライフを超えてる時だけ渡す
        if(currentLife <= damage)
        {
            // エナジーを受け渡す
            player.GetComponent<Player1Controller>().currentEnergy += this.currentEnergy;

        }

    }



    
}
