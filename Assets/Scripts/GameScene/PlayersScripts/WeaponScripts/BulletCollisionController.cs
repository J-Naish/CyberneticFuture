using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 弾丸に関するクラス
public class BulletCollisionController : BaseWeaponController
{

    private void Awake()
    {
        // ダメージを定義
        damage = 30.0f;

        // 武器の種類を定義
        // 衝突処理(ダメージ処理)が行われるようになる
        isCollisionWeapon = true;
        isBullet = true;
    }




}
