using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// マッチング完了画面に関するクラス
public class MatchingScreenController : MonoBehaviour
{

    // マッチング画面に用いる画像を取得
    [SerializeField] private Image[] matchmakingImageArray = new Image[3];


    // とりあえず秒数に応じて画像を表示してく
    private float currentTime = 0f;



    void Start()
    {
        // 初期は画像を表示しない
        for(int i = 0;i <= 2; i++)
        {
            matchmakingImageArray[i].GetComponent<Image>().enabled = false;
        }

    }

    
    void Update()
    {
        // 秒数カウント開始
        currentTime += Time.deltaTime;

        ShowMatchmakingSuccesful();
    }



    // マッチング完了を知らせる画像を表示する関数
    private void ShowMatchmakingSuccesful()
    {

        // 5秒経てば1つ目の画像表示
        if (currentTime >= 5.0f)
        {
            matchmakingImageArray[0].GetComponent<Image>().enabled = true;
        }
        // 2つ目表示
        if (currentTime >= 6.5f)
        {
            matchmakingImageArray[1].GetComponent<Image>().enabled = true;
        }
        // 3つ目表示
        if (currentTime >= 8.0f)
        {
            matchmakingImageArray[2].GetComponent<Image>().enabled = true;
        }

    }


}
