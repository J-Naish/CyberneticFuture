using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreResult : MonoBehaviour
{

    // 注入したエナジーをスコアとして取得するための変数
    private GameObject gameManager;
    private float scoreResult;


    // スコアを表示するUI
    private GameObject scoreText;


    // スコアをカウントアップ形式で表示するための変数
    private int scoreCountup;


    void Start()
    {

        // スコアテキストUI取得
        scoreText = GameObject.Find("ScoreText");


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

        // 毎フレームごとに表示するスコアを1ずつ加算してカウントアップ形式で表示
        if(scoreCountup <= scoreResult)
        {

            scoreText.GetComponent<TextMeshProUGUI>().text = scoreCountup.ToString("F0");

            scoreCountup++;

        }



    }
}
