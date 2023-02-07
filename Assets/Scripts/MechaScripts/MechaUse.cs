using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MechaUse : MonoBehaviour
{

    // メカの使用をキーから検知するための変数
    public bool useMecha = false;


    // メカボタンを取得(メカ所持のbool値を変更するため)
    [SerializeField] private GameObject mechaEmpty;



    void Update()
    {

        

        if (Input.GetKey(KeyCode.M))
        {
            useMecha = true;

            // メカを使用したのでメカボタンを半透明に
            mechaEmpty.GetComponent<MechaButton>().hasMecha = false;
        }

    }
}
