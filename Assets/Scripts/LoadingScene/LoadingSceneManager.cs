using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// LoadingSceneからゲームSceneに遷移するクラス
// とりあえず7秒経てばゲームSceneに遷移
public class LoadingSceneManager : BaseSceneManager
{

    private void Awake()
    {
        // 黒画像を初期では表示させない
        SetBlackImageActivity(false);
    }



    void Update()
    {
        SceneFadeAway();

        LoadGameScene();
    }


    // LoadingSceneに遷移する関数
    private void LoadGameScene()
    {
        // フェードアウトが終われば遷移
        if (fadingNumber == framesForFadingAway)
        {
            SceneManager.LoadScene("Field1");
        }

    }


}
