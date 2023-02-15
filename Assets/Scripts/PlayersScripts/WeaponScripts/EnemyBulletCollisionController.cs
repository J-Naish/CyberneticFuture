using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 弾が当たった時の処理に関するクラス
public class EnemyBulletCollisionController : MonoBehaviour
{

    // 弾が与えるダメージ数を定義
    public float enemyBulletDamage = 100.0f;
    

    // 弾がPlayerに当たった時の処理
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突対象がPlayerの場合のみ
        if (collision.gameObject.CompareTag("Player"))
        {
            // 弾がPlayerに当たったら弾を破壊
            Destroy(this.gameObject);
        }

    }


}
