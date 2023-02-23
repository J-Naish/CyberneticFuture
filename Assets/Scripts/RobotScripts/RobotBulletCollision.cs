using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ロボットの弾丸がダメージを与えるクラス
public class RobotBulletCollision : MonoBehaviour
{

    // 弾丸が与えるダメージ
    [SerializeField] private float damage = 10.0f;

    // 弾が当たった場合の処理
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player1Controller>().currentLife -= damage;
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().currentLife -= damage;
            Destroy(this.gameObject);
        }
    }


}
