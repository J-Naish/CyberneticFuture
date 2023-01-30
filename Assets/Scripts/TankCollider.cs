using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCollider : MonoBehaviour
{

    [SerializeField] private Image buttonImage;

    // Playerのエナジーを吸収するためにPlayerを取得
    private GameObject player;
    private float currentEnergy;

    // Tankのエナジーを増やすためにTankを取得
    private GameObject tank;
    private float currentTankEnergy;

    // エナジーの注入量
    private float pouringEnergy;


    // 範囲内にプレイヤーがいるかどうか
    private bool isInArea;



    private void Start()
    {

        // 普段はエナジー注入ボタンは表示させない
        buttonImage.enabled = false;


        // Player1の現在エナジー量を取得
        player = GameObject.Find("Player1");
        // この変数を代入して使うと0になるためコメントアウト 1/2
        // currentEnergy = player.GetComponent<Player1Controller>().currentEnergy;


        // Tankの現在エナジー量を取得
        tank = GameObject.Find("EnergyTank");
        currentTankEnergy = tank.GetComponent<TankController>().currentTankEnergy;


        // エナジー注入量
        pouringEnergy = 1.0f;


        // 初期は範囲にいないためfalseに
        isInArea = false;


    }


    private void Update()
    {

        if (isInArea)
        {

            // Playerのエナジーが0になれば注入できなくする
            if (player.GetComponent<Player1Controller>().currentEnergy >= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {

                    // Playerのエナジーを減らす
                    player.GetComponent<Player1Controller>().currentEnergy -= pouringEnergy;

                    // Tankのエナジーを増やす
                    currentTankEnergy += pouringEnergy;



                }
            }

        }

    }




    private void OnTriggerStay(Collider other)
    {

        // 衝突対象がPlayerの場合
        if (other.CompareTag("Player"))
        {
            // 近づいてる間だけ表示させる
            buttonImage.enabled = true;

            // 範囲内にいるのでtrueに
            isInArea = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {

        // Playerが範囲から脱出する場合
        if (other.CompareTag("Player"))
        {

            // 離れたら画像を表示させない
            buttonImage.enabled = false;

            // 範囲外にいるのでfalseに
            isInArea = false;

        }

    }




}
