using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 必殺技ボタンの表示に関するクラス
// 必殺技が溜まるまでボタンを半透明にする
public class SuperPowerButton : MonoBehaviour
{

    // 必殺技ボタンを取得
    [SerializeField] private Image superPowerButton;


    // 必殺技が溜まってるかどうかのbool値
    public bool isSuperPowerChaarged = false;


    
    void Update()
    {

        SetSuperPowerButtonOpacity();

    }


    // 必殺技の利用可能かどうかに応じてボタンの透明度を変更
    private void SetSuperPowerButtonOpacity()
    {

        if (isSuperPowerChaarged)
        {
            float alphaValue = 1.0f;
            SetOpacity(alphaValue);
        }
        else if (!isSuperPowerChaarged)
        {
            float alphaValue = 0.4f;
            SetOpacity(alphaValue);
        }

    }


    // ボタンの透明度を変更する関数
    private void SetOpacity(float alphaValue)
    {
        // imageのcolorを取得
        var c = superPowerButton.color;
        // colorはそのままでalphaを変更する
        superPowerButton.color = new Color(c.r, c.g, c.b, alphaValue);
    }


}
