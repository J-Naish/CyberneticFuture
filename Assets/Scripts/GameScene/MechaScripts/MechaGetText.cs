using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MechaGetText : MonoBehaviour
{

    // メカを取得したらtrueになるbool値
    // MechaColliderクラスでメカの近くでGキーを押すとtrueにするよう定義
    public bool gotMehca = false;


    // テキストを表示する秒数を指定するための変数
    private float currentTime = 0f;
    private float duration = 2.0f;


    [SerializeField] public TextMeshProUGUI mechaGetText;



    private void Start()
    {
        // メカ獲得テキストをデフォルトでは表示させないようにする
        mechaGetText.GetComponent<TextMeshProUGUI>().enabled = false;
    }


    void Update()
    {
        ShowMechaGetText();

    }


    // メカを取得したらテキストを表示する関数
    private void ShowMechaGetText()
    {
        // メカを取得した場合だけ処理を起こす
        if (gotMehca)
        {

            // 時間の加算開始
            currentTime += Time.deltaTime;

            // 2秒間だけ表示
            if(currentTime < duration)
            {
                mechaGetText.GetComponent<TextMeshProUGUI>().enabled = true;
            }
            else if(currentTime > duration)
            {
                // 2秒表示した後は非表示に
                mechaGetText.GetComponent<TextMeshProUGUI>().enabled = false;
                Destroy(this.gameObject);
            }
        }

    }


}
