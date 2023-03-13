using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// UIの表示に関するクラス
public class JoinMatchingImageController : MonoBehaviour
{

    // マッチング画面へ行く事を表す画像を取得
    [SerializeField] private Image joinMatchingImage;

    // キャラが近づく事を検知するオブジェクトを取得
    [SerializeField] private GameObject collisionDetector;




    private void Start()
    {
        // デフォルトではUIを表示しない
        joinMatchingImage.GetComponent<Image>().enabled = false;

    }


    void Update()
    {
        ShowImage();
    }


    // UI表示の関数
    private void ShowImage()
    {

        // 特定範囲内にいる時のみ表示
        if (collisionDetector.GetComponent<CollsionDetector>().isInArea)
        {
            // 画像を有効化
            joinMatchingImage.GetComponent<Image>().enabled = true;
        }
        else
        {
            // 画像を無効に
            joinMatchingImage.GetComponent<Image>().enabled = false;
        }

    }



}
