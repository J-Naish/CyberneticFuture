using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Scene遷移用のスクリプト
public class LoginSceneManager : MonoBehaviour
{

    
    void Update()
    {

        LoadHomeScene();

    }

    // HomeSceneへ遷移するための関数
    private void LoadHomeScene()
    {
        // Returnキーで検知
        if (Input.GetKeyDown(KeyCode.Return))
        {

            // Homeへ遷移
            SceneManager.LoadScene("Home");

        }

    }

}
