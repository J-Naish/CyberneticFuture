using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// パーティクルが衝突した時の処理に関するクラス
public class ParticleCollision : MonoBehaviour
{

    // ダメージを定義
    private float damage = 1.0f;

    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player1Controller>().currentLife -= damage;
            other.gameObject.GetComponent<Player1Controller>().animator.SetTrigger("Hindered");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().currentLife -= damage;
        }

    }


}
