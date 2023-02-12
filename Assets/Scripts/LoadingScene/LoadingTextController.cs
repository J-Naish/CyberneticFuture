using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextController : MonoBehaviour
{

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
