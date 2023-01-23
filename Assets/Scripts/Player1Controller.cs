using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : BasePlayer
{

    [SerializeField] private Animator animator;

    void Start()
    {

        // ステータス設定
        grossLife = 100.0f;
        grossEnergy = 100.0f;
        moveVelocity = 0.1f;
        attackPoint = 10.0f;
        attackSpeed = 2.0f;
        defensePoint = 10.0f;
        superPowerCoolTime = 50;


        // 初期位置を取得
        latestPosition = transform.position;
        


    }
    

    void Update()
    {
        MoveByArrowKey();
        animator.SetFloat("MoveSpeed",0.1f); // diff.magnitudeでやりたいけどできないからとりあえず数値で
    }


}
