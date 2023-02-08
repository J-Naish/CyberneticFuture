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
        int x = Random.Range(1,2);


        // 取得した乱数に応じてメカをactiveに
        if(x == 1)
        {
            // メカをPrefab化

            // プレファブ元のスクリプトを有効に
            superShoes.GetComponent<MechaSuperShoes>().enabled = true;
            // プレファブ化
            GameObject SuperShoes = Instantiate(superShoes);
            // プレファブ元のスクリプトがダブって効果が出ないように無効に
            superShoes.GetComponent<MechaSuperShoes>().enabled = false;

            // どのメカを獲得したかわかるようにする文字列
            mechaTypeText = "SuperShoes";
        }

        else if(x == 2)
        {
            // メカをPrefab化

            // プレファブ元のスクリプトを有効に
            superHelmet.GetComponent<MechaSuperHelmet>().enabled = true;
            // プレファブ化
            GameObject SuperHelmet = Instantiate(superHelmet);
            // プレファブ元のスクリプトがダブって効果が出ないように無効に
            superHelmet.GetComponent<MechaSuperShoes>().enabled = false;

            // どのメカを獲得したかわかるようにする文字列
            mechaTypeText = "SuperHelmet";

        }
        else  if(x == 3)
        {
            // メカをPrefab化

            // プレファブ元のスクリプトを有効に
            energyCharger.GetComponent<MechaEnergyCharger>().enabled = true;
            // プレファブ化
            GameObject EnergyCharger = Instantiate(energyCharger);
            // プレファブ元のスクリプトを有効に
            energyCharger.GetComponent<MechaEnergyCharger>().enabled = false;

            //// 他のメカを無効に
            //superShoes.GetComponent<MechaSuperShoes>().enabled = false;
            //superHelmet.GetComponent<MechaSuperShoes>().enabled = false;

            // どのメカを獲得したかわかるようにする文字列
            mechaTypeText = "EnergyCharger";

        }

    }




}
