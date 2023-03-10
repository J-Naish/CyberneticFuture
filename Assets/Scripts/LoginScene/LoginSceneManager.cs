using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Scene遷移用のスクリプト
public class LoginSceneManager : MonoBehaviour
{

    // フェードアウト用の黒画像を取得
    [SerializeField] private Image blackImage;

    // フェードアウトが終わるまでにかかるフレーム数
    private float framesForFadingAway = 180f;

    // フェードアウト(透明度調整)に用いる変数
    private float fadingNumber = 0f;

    // Enterが押された事を検知するbool値
    private bool isLodinghomeScene = false;


    private void Awake()
    {
        // 黒画像を初期では表示させない
        blackImage.enabled = false;
    }


    private void Update()
    {
        SceneFadeAway();

        LoadhomeScene();
    }
    


    // 徐々にフェードアウトするための関数
    private void SceneFadeAway()
    {
        // EnterキーでHomeSceneへ
        if (Input.GetKey(KeyCode.Return))
        {
            isLodinghomeScene = true;
        }

        if (isLodinghomeScene)
        {
            // 画像を有効化
            blackImage.enabled = true;

            // 画像のColorを取得(画像の透明度調整のため)
            var c = blackImage.GetComponent<Image>().color;

            // 黒画像の透明度変更
            blackImage.GetComponent<Image>().color = new Color(c.r, c.g, c.b, fadingNumber / framesForFadingAway);

            // 徐々に非透明にするために加算
            fadingNumber += 1f;
        }
    }


    // Scene遷移の関数
    private void LoadhomeScene()
    {
        // フェードアウトが完了したらScene遷移
        if(fadingNumber == framesForFadingAway)
        {
            SceneManager.LoadScene("Home");
        }
    }


}
