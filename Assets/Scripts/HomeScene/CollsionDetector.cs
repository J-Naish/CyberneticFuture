using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 扉の近くにいることを検知するクラス
// UI表示に検知を用いる
public class CollsionDetector : MonoBehaviour
{

    public bool isInArea = false;


    // 範囲内にいる間はboolをtrueに
    private void OnTriggerStay(Collider other)
    {
        // 対象がPlayerの場合のみ検知
        if (other.CompareTag("Player"))
        {
            isInArea = true;
        }

    }


    // 範囲外に出たらboolをfalseに
    private void OnTriggerExit(Collider other)
    {
        // 対象がPlayerの場合のみ検知
        if (other.CompareTag("Player"))
        {
            isInArea = false;
        }

    }


}
