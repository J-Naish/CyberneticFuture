using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// ログインテキストの表示に関するスクリプト
public class LoginTextController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI loginText;


    // 透明度を変更するために用意した変数
    float x = 1.0f;
    float i = 240.0f;



    void Update()
    {
        FadeInAndOut();
    }



    // フェード表示するための関数
    private void FadeInAndOut()
    {
        
        // テキストの色を取得して透明度だけ操作
        var c = loginText.color;
        loginText.color = new Color(c.r, c.g, c.b, i/240);

        // 透明度を変更
        i -= x;

        // alphaが0または1になればalpha値の加算を変更
        if(i == 0f || i == 240.0f)
        {
            x *= -1.0f;
        }

    }


}
