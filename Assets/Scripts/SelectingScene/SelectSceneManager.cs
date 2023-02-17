using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// SelectSceneの遷移に関するクラス
public class SelectSceneManager : MonoBehaviour
{

    void Update()
    {
        LoadLoadingScene();
    }


    // LoadingSceneに遷移する関数
    private void LoadLoadingScene()
    {
        // Enterで遷移
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Loading");
        }

    }


}
