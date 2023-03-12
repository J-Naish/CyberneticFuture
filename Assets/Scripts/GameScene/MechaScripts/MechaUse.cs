using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// メカの使用に関するクラス
public class MechaUse : MonoBehaviour
{

    // メカの使用をキーから検知するための変数
    public bool useMecha = false;


    // メカボタンを取得(メカ所持のbool値を変更するため)
    [SerializeField] private GameObject mechaEmpty;



    void Update()
    {
        UseMecha();
    }



    // メカを使用する関数
    private void UseMecha()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // メカ使用検知bool値を更新
            useMecha = true;

            // メカを使用したのでメカボタンを半透明に
            mechaEmpty.GetComponent<MechaButton>().hasMecha = false;
        }
    }


}
