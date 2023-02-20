using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// Robotの共通基底クラス
public class RobotBase : MonoBehaviour
{

    // ロボットのステータス
    protected float robotGrossLife;
    public float robotCurrentLife;
    protected float robotEnergy;


    // ロボットのライフ表示用UI
    [SerializeField] protected GameObject lifeBar;
    protected Slider lifeSlider;


    // 攻撃してきたPlayerを取得するための変数
    protected GameObject player;
    protected float currentEnergyOfPlayer;


    /// <summary>
    /// ロボットのライフを設定する関数
    /// </summary>
    protected void SetRobotLife()
    {
        // ライフの設定
        robotCurrentLife = robotGrossLife;

        lifeSlider = lifeBar.transform.Find("Slider").GetComponent<Slider>();
        lifeSlider.value = 1f;
    }


    /// <summary>
    /// ライフのバーを更新する関数
    /// </summary>
    protected void BarChange()
    {
        lifeSlider.value = (float)robotCurrentLife / (float)robotGrossLife;
    }


    /// <summary>
    /// ライフが0以下になれば破壊される関数
    /// </summary>
    protected void BreakWhenDeath()
    {
        if(robotCurrentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
