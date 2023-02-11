using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// HomeSceneの遷移に関するクラス
public class HomeSceneManager : MonoBehaviour
{

    [SerializeField] private GameObject collisionDetector;

    
    
    void Update()
    {
        LoadMatchingScene();
    }


    // Scene遷移の関数
    private void LoadMatchingScene()
    {
        // 範囲内にいる時に
        if (collisionDetector.GetComponent<CollsionDetector>().isInArea)
        {
            // リターンキーを押したら
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // マッチングシーンへ遷移
                SceneManager.LoadScene("Matching");
            }
        }

    }


}
