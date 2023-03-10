using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// HomeSceneの遷移に関するクラス
public class HomeSceneManager : BaseSceneManager
{

    // 衝突検知オブジェクトを取得
    [SerializeField] private GameObject collisionDetector;


    private void Awake()
    {
        // 黒画像を初期では表示させない
        SetBlackImageActivity(false);
    }



    void Update()
    {
        SceneFadeAway();

        LoadMatchingScene();
    }



    // Sceneフェードアウトの関数
    protected override void SceneFadeAway()
    {
        // 中央の扉の範囲内にいない時はreturn
        if (!collisionDetector.GetComponent<CollsionDetector>().isInArea) return;

        // EnterキーでHomeSceneへ
        if (Input.GetKey(KeyCode.Return))
        {
            isLodingNextScene = true;
        }

        if (isLodingNextScene)
        {
            // 画像を有効化
            SetBlackImageActivity(true);

            // 画像のColorを取得(画像の透明度調整のため)
            var c = blackImage.GetComponent<Image>().color;

            // 黒画像の透明度変更
            blackImage.GetComponent<Image>().color = new Color(c.r, c.g, c.b, fadingNumber / framesForFadingAway);

            // 徐々に非透明にするために加算
            fadingNumber += 1f;
        }
    }



    // Scene遷移の関数
    private void LoadMatchingScene()
    {
        // フェードアウトが完了したらScene遷移
        if (fadingNumber == framesForFadingAway)
        {
            SceneManager.LoadScene("Matching");
        }
    }


}
