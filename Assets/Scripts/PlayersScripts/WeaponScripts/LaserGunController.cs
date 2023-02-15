using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// レーザー銃に関するクラス
public class LaserGunController : BaseWeaponController
{
    // レーザーの発射元の位置を取得
    [SerializeField] private GameObject muzzle;
    private Vector3 muzzlePosition;

    // レーザーのスピードを定義
    private float laserSpeed = 5000.0f;


    private void Awake()
    {
        // ステータスを設定
        SetStatus(800.0f, 700.0f, 9.0f);

    }


    void Start()
    {

        // エナジー消費量を設定
        requiringEnergy = 20.0f;

        // 弾を発射する位置を取得
        muzzlePosition = muzzle.transform.position;
    }

    
    void Update()
    {
        
    }
}
