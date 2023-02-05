using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// メカに近づくと獲得ボタンを表示したりできるクラス
public class MechaCollider : MonoBehaviour
{

    [SerializeField] private Image mechaGetButton;


    private void Start()
    {

        // デフォルトでは表示させない
        mechaGetButton.enabled = false;

    }


    private void OnTriggerStay(Collider other)
    {
        // 範囲内にいればメカ獲得ボタンを表示
        mechaGetButton.enabled = true;

    }


    private void OnTriggerExit(Collider other)
    {

        // 範囲外に出ればメカ獲得ボタンを非表示
        mechaGetButton.enabled = false;
    }


}
