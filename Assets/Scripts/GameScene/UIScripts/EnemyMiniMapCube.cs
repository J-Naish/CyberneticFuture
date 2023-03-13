using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 敵のミニマップ表示用のCubeに関するクラス
public class EnemyMiniMapCube : MonoBehaviour
{

    private void Start()
    {
        // デフォルトではCubeを非表示に
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }


    // 範囲内にいる時のみCubeを表示させる処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }



}
