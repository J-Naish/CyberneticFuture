using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SelectSceneの遷移に関するクラス
public class SelectSceneManager : BaseSceneManager
{

    private void Awake()
    {
        // 黒画像を初期では表示させない
        SetBlackImageActivity(false);
    }


    void Update()
    {
        SceneFadeAway();

        LoadLoadingScene();
    }


    // LoadingSceneに遷移する関数
    private void LoadLoadingScene()
    {
        // フェードアウトが終われば遷移
        if (fadingNumber == framesForFadingAway)
        {
            SceneManager.LoadScene("Loading");
        }

    }


}
