using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// メカボックス生成前にオブジェクトに衝突しないか検知するクラス
public class MechaBoxCollisionDetector : MonoBehaviour
{

    public bool isCollidered = false;


    private void OnTriggerStay(Collider other)
    {
        isCollidered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollidered = false;
    }


}