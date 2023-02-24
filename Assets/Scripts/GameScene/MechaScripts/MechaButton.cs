using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// メカ使用ボタンUIに関するクラス
public class MechaButton : MonoBehaviour
{

    // メカボタンオブジェクトを取得
    [SerializeField] private Image mechaButtonImage;

    // メカを持ってるかどうかの変数
    public bool hasMecha;

    void Start()
    {
        // 初期はメカを持ってないのでfalse
        hasMecha = false;

    }

    
    void Update()
    {

        SetOpacity();

    }


    // 透明度を変更する関数
    private void SetOpacity()
    {

        if (hasMecha)
        {
            // メカを非透明に

            // imageのcolorを取得
            var c = mechaButtonImage.color;
            // colorはそのままでalphaを変更する
            mechaButtonImage.color = new Color(c.r, c.g, c.b, 1.0f);
        }
        else
        {
            // メカを透明に

            // imageのcolorを取得
            var c = mechaButtonImage.color;
            // colorはそのままでalphaを変更する
            mechaButtonImage.color = new Color(c.r, c.g, c.b, 0.4f);

        }

    }

}
