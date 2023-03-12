using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Scene遷移の基底クラス
public class BaseSceneManager : MonoBehaviour
{

    // フェードアウト用の黒画像を取得
    [SerializeField] protected Image blackImage;

    // フェードアウトが終わるまでにかかるフレーム数
    protected float framesForFadingAway = 180f;

    // フェードアウト(透明度調整)に用いる変数
    protected float fadingNumber = 0f;

    // Enterが押された事を検知するbool値
    public bool isLodingNextScene = false;



    // 徐々にフェードアウトするための関数
    protected virtual void SceneFadeAway()
    {
        // EnterキーでHomeSceneへ
        if (Input.GetKey(KeyCode.Return))
        {
            isLodingNextScene = true;
        }

        if (isLodingNextScene)
        {
            // 画像を有効化
            SetBlackImageActivity(true);

            // 画像のColorを取得(画像の透明度調整のため)
            var c = blackImage.GetComponent<Image>().color;

            // 黒画像の透明度変更
            blackImage.GetComponent<Image>().color = new Color(c.r, c.g, c.b, fadingNumber / framesForFadingAway);

            // 徐々に非透明にするために加算
            fadingNumber += 1f;
        }
    }



    // 黒画像の有効・非有効を切り替える関数
    protected void SetBlackImageActivity(bool b)
    {
        // 引数に基づき背景画像を有効・非有効に
        blackImage.enabled = b;
    }


}
