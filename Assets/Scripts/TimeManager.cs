using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    // カウントダウンのテキストを取得
    private GameObject timerText;


    // 時間を定義
    private float totalTime;
    private int minute;
    private float second;


    // 文字の色変更のための色宣言
    private Color greenColor = new Color(0.1f, 0.6f, 0, 1);
    private Color redColor = new Color(0.6f, 0, 0, 1);


    // タイムアップ用のテキストを取得
    [SerializeField] private TextMeshProUGUI timeupText;


    // Resultシーンでもスコアを持ち越すためにGameManagerオブジェクトを取得
    private GameObject gameManager;



    void Start()
    {
        this.timerText = GameObject.Find("TimerText");

        // 制限時間8:00
        minute = 0; 
        second = 30.0f;
        totalTime = minute * 60 + second;


        // タイムアップテキストは時間が0になるまで表示させない
        timeupText.enabled = false;


        // GameManagerを取得  
        gameManager = GameObject.Find("GameManager");

        // GameManagerを遷移先のシーンでも保持
        DontDestroyOnLoad(gameManager);

    }



    void Update()
    {

        totalTime -= Time.deltaTime;
        minute = (int)totalTime / 60;
        second = totalTime - minute * 60;


        // ゲーム終了処理
        if (totalTime <= 0)
        {

            // 時間の流れを停止する
            Time.timeScale = 0.1f;

            // タイムアップテキストを表示させる
            timeupText.enabled = true;


            // 表示時間を00:00で固定
            this.timerText.GetComponent<TextMeshProUGUI>().text = "00:00";


        }


        // タイムアップを表示した0.5秒後にリザルト画面にシーン遷移
        if(totalTime <= -0.5f)
        {

            // リザルト画面へ
            SceneManager.LoadScene("Result");


        }


        if (totalTime > 0)
        {


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
                // ※00:60というような表記をなくす処理が必要
            }

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
