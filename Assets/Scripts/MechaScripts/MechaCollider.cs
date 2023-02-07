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
    // どのメカを取得したかのテキスト
    private string mechaTypeText;


    // それぞれのメカを取得
    [SerializeField] private GameObject superShoes;
    [SerializeField] private GameObject superHelmet;
    [SerializeField] private GameObject energyCharger;


    // メカ所持時にはメカを取得できないようにメカボタンを取得
    [SerializeField] private GameObject mechaButton;



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

            // メカを持ってない時のみ取得できる
            if (!mechaButton.GetComponent<MechaButton>().hasMecha)
            {

                // Gキーでメカを獲得
                if (Input.GetKeyDown(KeyCode.G))
                {

                    // メカ所持のbool値を変更
                    mechaEmpty.GetComponent<MechaButton>().hasMecha = true;


                    // Playerがメカを取得
                    GetNewMecha();


                    // メカ獲得テキストを表示させる
                    mechaGetText.GetComponent<TextMeshProUGUI>().text = "You've got " + mechaTypeText;
                    mechaGetText.GetComponent<MechaGetText>().gotMehca = true;



                    // メカを取得したらメカボックスを破壊
                    Destroy(this.gameObject);

                }

            }

        }

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // 範囲内にいればメカ獲得ボタンを表示
            mechaGetButton.enabled = true;

            // 範囲内にいればtrue
            isInMechaBoxArea = true;

        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // 範囲外に出ればメカ獲得ボタンを非表示
            mechaGetButton.enabled = false;

            // 範囲外に出ればflaseに
            isInMechaBoxArea = false;
        }
    }



    // アイテムを取得する関数
    private void GetNewMecha()
    {

        // 乱数を生成
        int x = Random.Range(1,4);


        // 取得した乱数に応じてメカをactiveに
        if(x == 1)
        {

            superShoes.GetComponent<MechaSuperShoes>().enabled = true;
            mechaTypeText = "SuperShoes";
        }

        else if(x == 2)
        {

            superHelmet.GetComponent<MechaSuperHelmet>().enabled = true;
            mechaTypeText = "SuperHelmet";

        }
        else  if(x == 3)
        {

            energyCharger.GetComponent<MechaEnergyCharger>().enabled = true;
            mechaTypeText = "EnergyCharger";

        }

    }




}
