using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 選択してない武器画像を薄暗くするためのクラス
public class BlackImage : MonoBehaviour
{

    // 黒画像を取得
    // これの半透明にして薄暗くする
    [SerializeField] private Image blackImage;


    // 該当武器が選択されてるか選択されてないかのbool値
    public bool isSelected = false;


    
    void Update()
    {
        ChangeOpacity();
    }


    // 選択されてない武器画像を薄暗くする関数
    private void ChangeOpacity()
    {
        // 選択されてない時は薄暗くする
        if (!isSelected)
        {
            float alphaValue = 0.5f;
            SetOpacity(alphaValue);
        }
        // 選択されてない時は画像をそのまま表示
        else if (isSelected)
        {
            float alphaValue = 0f;
            SetOpacity(alphaValue);
        }

    }


    // 透明度を変更する関数
    private void SetOpacity(float alphaValue)
    {
        // imageのcolorを取得
        var c = blackImage.color;
        // colorはそのままでalphaを変更する
        blackImage.color = new Color(c.r, c.g, c.b, alphaValue);
    }


}
