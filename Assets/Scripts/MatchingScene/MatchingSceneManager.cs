using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// MatchingSceneの遷移に関するクラス
// とりあえず5秒経てばLoadingSceneへ
public class MatchingSceneManager : MonoBehaviour
{

    // 秒数を扱うための変数
    private float currentTime = 0f;

    
    void Update()
    {

        // カウント開始
        currentTime += Time.deltaTime;


        LoadGameScene();

        CancelMatchingToHome();

    }



    // マッチングをキャンセルしてHomeSceneに戻る関数
    private void CancelMatchingToHome()
    {

        // 5秒経つまではキャンセルできる
        if (currentTime < 5.0f)
        {
            // Cキーでマッチングキャンセル
            if (Input.GetKeyDown(KeyCode.C))
            {
                // キャンセルしたらHomeへ
                SceneManager.LoadScene("Home");
            }

        }

    }


    // LoadingSceneへ遷移する関数
    private void LoadGameScene()
    {

        // 5秒経てばロード開始
        if(currentTime >= 10.0f)
        {
            
            SceneManager.LoadScene("Loading");

        }

    }


}
