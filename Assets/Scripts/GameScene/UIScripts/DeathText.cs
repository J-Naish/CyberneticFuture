using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// デスした時に表示するUIに関するクラス
public class DeathText : MonoBehaviour
{

    // 画面を暗くするための背景画像UIを取得
    [SerializeField] private Image backgroundImage;
    // デス時の表示テキストを取得
    [SerializeField] private TextMeshProUGUI deathText;

    // デスした情報を取得
    [SerializeField] private GameObject deathController;



    void Start()
    {
        // デフォルトではデスUIを非表示
        DeathTextOnOrOff(false);

    }

    
    void Update()
    {
        // デスタイム分だけUIを表示
        ShowDeathText();
    }


    // t秒間デスUIを表示する関数
    private void ShowDeathText()
    {

        // 死んだ時だけ処理を行う
        if (deathController.GetComponent<DeathController>().isUnder0Life)
        {
            DeathTextOnOrOff(true);
        }
        else if (!deathController.GetComponent<DeathController>().isUnder0Life)
        {
            DeathTextOnOrOff(false);
        }

    }


    // デス時UIを表示・非表示する関数
    private void DeathTextOnOrOff(bool b)
    {
        backgroundImage.enabled = b;
        deathText.enabled = b;
    }


}
