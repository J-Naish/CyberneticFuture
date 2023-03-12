using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// スコアを集計しリザルト画面で表示させるクラス
public class ScoreResult : MonoBehaviour
{

    // 注入したエナジーをスコアとして取得するための変数
    private GameObject gameManager;
    private float scoreResult;

    // スコアを表示するUI
    [SerializeField] private GameObject scoreText;


    // スコアをカウントアップ形式で表示するための変数
    private int scoreCountup;



    void Start()
    {
        // GameManagerを取得
        gameManager = GameObject.Find("GameManager");

        // エナジースコアを取得
        // 敵がいない想定なのでとりあえず左チームのものを取得
        scoreResult = gameManager.GetComponent<GameManager>().currentLeftTotalEnergy;

        // スコアを高速表示させるために変更
        Time.timeScale = 5.0f;

        // スコアのカウントアップは0からスタート
        scoreCountup = 0;

    }



    void Update()
    {
        ShowScoreResult();
    }



    // スコア結果を表示させる関数
    private void ShowScoreResult()
    {
        // 毎フレームごとに表示するスコアを1ずつ加算してカウントアップ形式で表示
        if (scoreCountup <= scoreResult)
        {
            // スコアテキストを定義
            scoreText.GetComponent<TextMeshProUGUI>().text = scoreCountup.ToString("F0");

            // スコアを加算
            scoreCountup++;
        }
    }


}
