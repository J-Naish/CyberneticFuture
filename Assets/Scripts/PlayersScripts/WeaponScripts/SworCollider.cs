using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 剣が敵に当たった時に関する処理
public class SworCollider : MonoBehaviour
{

    // 当たった時に与えるダメージ
    private float damage = 120.0f;


    // 衝突した時の処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.root.gameObject.GetComponent<EnemyController>().currentLife -= damage;
        }
        if (other.CompareTag("Robot"))
        {
            other.transform.root.gameObject.GetComponent<RobotAController>().robotCurrentLife -= damage;
        }

    }


}
