using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// デス時の黒の背景画像の透明度を変えるUI
public class DeathBackground : MonoBehaviour
{
    // 背景画像の透明度
    private float backgroundAlpha = 0.4f;

    
    void Start()
    {
        SetOpacity(backgroundAlpha);
    }

    
    void Update()
    {
        
    }


    // 透明度を変える関数
    private void SetOpacity(float alpha)
    {

        // Imageコンポーネントを取得
        Image backgroundImage = this.gameObject.GetComponent<Image>();
        // imageのcolorを取得
        var c = backgroundImage.color;
        // colorはそのままでalphaを変更する
        backgroundImage.color = new Color(c.r, c.g, c.b, alpha);

    }


}
