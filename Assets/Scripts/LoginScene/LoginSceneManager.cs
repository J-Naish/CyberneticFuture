using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Scene遷移用のスクリプト
// SceneManagerの基底クラスを継承
public class LoginSceneManager : BaseSceneManager
{

    private void Awake()
    {
        // 黒画像を初期では表示させない
        SetBlackImageActivity(false);
    }


    private void Update()
    {
        SceneFadeAway();

        LoadHomeScene();
    }
    

    // Scene遷移の関数
    private void LoadHomeScene()
    {
        // フェードアウトが完了したらScene遷移
        if(fadingNumber == framesForFadingAway)
        {
            SceneManager.LoadScene("Home");
        }
    }


}
