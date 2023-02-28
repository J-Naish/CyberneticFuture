using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ミニマップの表示に関するクラス
public class FieldMiniMapController : MonoBehaviour
{

    [SerializeField] private GameObject energyTank2;
    [SerializeField] private GameObject energyTank3;


    // 範囲内に入ったらミニマップに表示させる
    private void OnTriggerStay(Collider other)
    {
        //// もしタンクのうちの片方でも残ってたら表示させない
        if (energyTank2 == null && energyTank3 == null)
        {
            return;
        }

        // 敵が範囲内に入っていたらミニマップに表示
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.Find("MiniMapCube").gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    // 範囲外に出たら非表示にする
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.Find("MiniMapCube").gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }


}
