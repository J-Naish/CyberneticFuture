using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// メカ使用ボタンUIに関するクラス
public class MechaButton : MonoBehaviour
{

    // メカボタンオブジェクトを取得
    [SerializeField] private Image mechaButtonImage;



    void Start()
    {

        // UIの色をメカを取得するまで半透明に
        SetOpacity(mechaButtonImage, 0.2f);

    }

    
    void Update()
    {
        
    }


    // 透明度を変更する関数
    private void SetOpacity(Image image,float alpha)
    {
        // imageのcolorを取得
        var c = image.color;
        // colorはそのままでalphaを変更する
        image.color = new Color(c.r, c.g, c.b, alpha);
    }

}
