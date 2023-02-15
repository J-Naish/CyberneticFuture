using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{

    // 銃弾がヒットした時に与えるダメージの変数
    public float damage;

    private void Update()
    {
        // ダメージ数を定義
        damage = 150.0f;
    }

}
