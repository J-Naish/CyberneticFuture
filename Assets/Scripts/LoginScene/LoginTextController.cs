using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
        

        var c = loginText.color;
        loginText.color = new Color(c.r, c.g, c.b, i/240);

        i -= x;

        // alphaが0になればalpha値を増やしていく
        if(i == 0f)
        {
            x = -1.0f;
        }
        // alpha値が1になればalpha値を減らしていく
        else if(i == 240.0f)
        {
            x = 1.0f;
        }

    }


}
