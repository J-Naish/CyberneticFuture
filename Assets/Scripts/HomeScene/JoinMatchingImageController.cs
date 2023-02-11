using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UIの表示に関するクラス
public class JoinMatchingImageController : MonoBehaviour
{

    [SerializeField] private Image joinMatchingImage;

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
            joinMatchingImage.GetComponent<Image>().enabled = true;
        }
        else
        {
            joinMatchingImage.GetComponent<Image>().enabled = false;
        }

    }





}
