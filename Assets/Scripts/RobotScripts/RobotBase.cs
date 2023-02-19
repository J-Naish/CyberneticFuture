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



}
