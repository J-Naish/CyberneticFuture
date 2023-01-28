using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{

    GameObject timerText;

    private float totalTime;
    private int minute;
    private float second;


    // 文字の色変更のための色宣言
    private Color greenColor = new Color(0.1f, 0.6f, 0, 1);
    private Color redColor = new Color(0.6f, 0, 0, 1);



    void Start()
    {
        this.timerText = GameObject.Find("TimerText");

        // 制限時間8:00
        minute = 8; 
        second = 0f;
        totalTime = minute * 60 + second;
    }



    void Update()
    {

        totalTime -= Time.deltaTime;
        minute = (int)totalTime / 60;
        second = totalTime - minute * 60;


        if (totalTime <= 0)
        {
            // ゲームオーバー処理
            // ゲーム監督用スクリプトからメソッドを呼び出す？
        }

        if (second >= 10)
        {
            this.timerText.GetComponent<TextMeshProUGUI>().text = "0" + minute.ToString("F0") + ":" + second.ToString("F0");
        }
        else if (second <= 9)
        {
            // 秒数が一桁になって見栄えが悪くならないようにする処理
            this.timerText.GetComponent<TextMeshProUGUI>().text = "0" + minute.ToString("F0") + ":0" + second.ToString("F0");
        }
        else if (second == 60)
        {
            // 00:60というような表記をなくす処理
        }


        if (minute >= 2)
        {
            // 残り2分までは緑字
            this.timerText.GetComponent<TextMeshProUGUI>().color = greenColor;
        }
        else if (minute < 2)
        {
            // 残り2分で赤字に
            this.timerText.GetComponent<TextMeshProUGUI>().color = redColor;
        }
    }
}
