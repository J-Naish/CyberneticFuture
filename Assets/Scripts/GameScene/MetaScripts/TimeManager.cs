using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


// ゲームの時間を管理するクラス
public class TimeManager : MonoBehaviour
{

    // カウントダウンのテキストを取得
    [SerializeField] private GameObject timerText;


    // 時間を定義
    // ゲーム開始演出のために0.1秒多くする
    public float totalTime;
    private int minute = 8;
    private float second = 0.1f;


    // 文字の色変更のための色宣言
    private Color greenColor = new Color(0.1f, 0.6f, 0, 1);
    private Color redColor = new Color(0.6f, 0, 0, 1);


    // タイムアップ用のテキストを取得
    [SerializeField] private TextMeshProUGUI timeupText;

    // ゲームスタート用のテキストを取得
    [SerializeField] private TextMeshProUGUI startText;


    // Resultシーンでもスコアを持ち越すためにGameManagerオブジェクトを取得
    [SerializeField] private GameObject gameManager;


    // 時間テキストの色を変える境目の時間
    private int nearlyFinishTime = 2;


    // 次のSceneへ遷移させる時の時間
    private float loadingNextSceneTime = -0.5f;


    // 1分は何秒かを表す変数
    private float secondsForMinute = 60.0f;


    // ゲーム再生速度をどれくらい減少させるかの変数
    private float decreasedGameSpeed = 0.1f;


    // ゲームの合計時間(秒)
    private float totalGameSeconds;



    void Start()
    {
        // 制限時間8:00
        totalTime = minute * secondsForMinute + second;


        // タイムアップテキストは時間が0になるまで表示させない
        timeupText.enabled = false;

        // Start()時点でスタートテキストは表示させない
        startText.enabled = false;


        // GameManagerを遷移先のシーンでも保持
        DontDestroyOnLoad(gameManager);


        // ゲームの合計時間を取得
        totalGameSeconds = minute * secondsForMinute;

    }




    void Update()
    {
        DefineTime();

        StartGameWithText();

        TerminateStartProccess();

        ShowTimerText();

        ChangeTimerTextColor();

        TimeUpToEndGame();

        LoadResultScene();

    }



    // 時間を定義しカウントダウンしてく関数
    private void DefineTime()
    {
        // 合計時間を減らしてく
        totalTime -= Time.deltaTime;

        // 時間を定義
        minute = (int)totalTime / 60;
        second = totalTime - minute * 60;
    }



    // ゲーム開始時にゲームの流れを遅くしテキストを表示させる関数
    private void StartGameWithText()
    {
        // 余分な0.1秒間だけの処理
        if (totalTime >= totalGameSeconds)
        {
            // ゲームの流れを遅くする
            Time.timeScale = decreasedGameSpeed;

            // ゲームスタートテキストを表示させる
            startText.enabled = true;
        }
    }



    // ゲームの再生速度を元に戻しテキストを非表示にする関数
    private void TerminateStartProccess()
    {
        // 余分な0.1秒分が経過したら処理を起こす
        if (totalTime < totalGameSeconds)
        {
            // 時間の流れを元に戻す
            Time.timeScale = 1.0f;

            // ゲームスタートテキストを非表示に
            startText.enabled = false;
        }
    }



    // 残り時間テキストの表示の関数
    private void ShowTimerText()
    {
        // 時間表示処理
        if (totalTime <= 0) return;

        // 時間表示処理
        if (second >= 10)
        {
            this.timerText.GetComponent<TextMeshProUGUI>().text = "0" + minute.ToString("F0") + ":" + second.ToString("F0");
        }
        // 秒数の表示が一桁にならないようにする処理
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



    // 残り時間に応じて文字色を変える関数
    private void ChangeTimerTextColor()
    {
        // フォントカラーの変更処理
        if (minute >= nearlyFinishTime)
        {
            // 残り2分までは緑字
            this.timerText.GetComponent<TextMeshProUGUI>().color = greenColor;
        }
        else if (minute < nearlyFinishTime)
        {
            // 残り2分で赤字に
            this.timerText.GetComponent<TextMeshProUGUI>().color = redColor;
        }
    }



    // ゲーム終了の関数
    private void TimeUpToEndGame()
    {
        // ゲーム終了処理
        if (totalTime <= 0)
        {
            // 時間の流れを停止する
            Time.timeScale = decreasedGameSpeed;

            // タイムアップテキストを表示させる
            timeupText.enabled = true;

            // 表示時間を00:00で固定させる
            this.timerText.GetComponent<TextMeshProUGUI>().text = "00:00";
        }
    }



    // リザルト画面へ遷移させる関数
    private void LoadResultScene()
    {
        // タイムアップを表示した0.5秒後にリザルト画面にシーン遷移
        if (totalTime <= loadingNextSceneTime)
        {
            // リザルト画面へ
            SceneManager.LoadScene("Result");
        }
    }



}
