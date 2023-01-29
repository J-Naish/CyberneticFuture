using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BasePlayer
{

    private float damage;
    private GameObject weapon;


    void Start()
    {
        grossLife = 1000.0f;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Weapon"))
        {
            weapon = other.gameObject;
            damage = weapon.GetComponent<BulletCollisionController>().damage;
            grossLife -= damage;

            // 衝突対象を破壊(剣などの場合は残す処理は必要)
            Destroy(weapon);

        }

    }


    void Update()
    {
        // ライフ0で消える処理
        if(grossLife <= 0)
        {
            Destroy(gameObject);
        }

    }

    
}
