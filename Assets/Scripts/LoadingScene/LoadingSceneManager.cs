using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// LoadingSceneからゲームSceneに遷移するクラス
// とりあえず7秒経てばゲームSceneに遷移
public class LoadingSceneManager : MonoBehaviour
{

    // 秒数を扱うための変数
    private float currentTime = 0f;

    
    void Update()
    {

        // 秒数をカウント
        currentTime += Time.deltaTime;


        LoadGameScene();

    }


    // ゲームSceneへ遷移する関数
    private void LoadGameScene()
    {

        // 7秒経てばゲームSceneへ
        if(currentTime >= 7.0f)
        {

            // フィールドを複数用意したらランダムで遷移するようにする
            SceneManager.LoadScene("Field1");

        }

    }


}
