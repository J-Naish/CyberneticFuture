using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// レベルを表示するテキストに関するクラス
public class LevelText : MonoBehaviour
{

    // Playerオブジェクトを取得
    [SerializeField] private GameObject player;

    // Playerの現在レベルを宣言
    private int currentLevel;


    void Update()
    {
        ShowingLevelUI();
    }


    // 現在レベルをUI表示させる関数
    private void ShowingLevelUI()
    {
        // Playerをレベルを定義
        currentLevel = player.GetComponent<Player1Controller>().playerLevel;

        // テキストをレベルに応じて変更
        GetComponent<TextMeshProUGUI>().text = "Level" + currentLevel.ToString("F0");
    }


}
