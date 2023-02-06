using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// メカに近づくと獲得ボタンを表示したりできるクラス
public class MechaCollider : MonoBehaviour
{

    // メカ獲得ボタンを取得
    [SerializeField] private Image mechaGetButton;

    // 範囲内にいるかどうかのBool値
    public bool isInMechaBoxArea;


    // メカボタンを取得(メカ所持のbool値を変更するため)
    [SerializeField] private GameObject mechaEmpty;


    // メカ獲得テキストを取得
    [SerializeField] private TextMeshProUGUI mechaGetText;



    private void Start()
    {

        // デフォルトではメカ獲得ボタンを表示させない
        mechaGetButton.enabled = false;

        // デフォルトでは範囲外
        isInMechaBoxArea = false;

        // デフォルトではメカ獲得テキストを非表示
        mechaGetText.enabled = false;

    }


    private void Update()
    {

        // 範囲内にいる時のみ呼び出す
        if (isInMechaBoxArea)
        {

            // Gキーでメカを獲得
            if (Input.GetKeyDown(KeyCode.G))
            {

                // メカ所持のbool値を変更
                mechaEmpty.GetComponent<MechaButton>().hasMecha = true;


                // メカ獲得テキストを表示させる
                mechaGetText.GetComponent<MechaGetText>().gotMehca = true;


                // Playerがメカを所持した状態に関する処理


                // メカを取得したらメカボックスを破壊
                Destroy(this.gameObject);

            }

        }

    }


    private void OnTriggerStay(Collider other)
    {
        // 範囲内にいればメカ獲得ボタンを表示
        mechaGetButton.enabled = true;

        // 範囲内にいればtrue
        isInMechaBoxArea = true;

    }


    private void OnTriggerExit(Collider other)
    {

        // 範囲外に出ればメカ獲得ボタンを非表示
        mechaGetButton.enabled = false;

        // 範囲外に出ればflaseに
        isInMechaBoxArea = false;

    }




}
