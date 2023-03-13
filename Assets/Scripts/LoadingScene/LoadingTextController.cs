using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// ロード中に表示させるテキストに関するクラス
public class LoadingTextController : MonoBehaviour
{
    // ローディングテキストを取得
    [SerializeField] private TextMeshProUGUI loadingText;


    // 透明度を変更するために用意した変数
    float x = 1.0f;
    float i = 480.0f;



    void Update()
    {
        FadeInAndOut();
    }



    // フェード表示するための関数
    private void FadeInAndOut()
    {
        // テキストの色を取得して透明度だけ操作
        var c = loadingText.color;
        loadingText.color = new Color(c.r, c.g, c.b, i / 240);

        i -= x;

        // alphaが0または1になればalpha値の加算を変更
        if (i == 0f || i == 480.0f)
        {
            x *= -1.0f;
        }
    }


}
