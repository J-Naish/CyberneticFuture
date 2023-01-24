using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : BasePlayer
{

    [SerializeField] private Animator animator;


    void Start()
    {

        // 速度係数
        moveVelocity = 0.1f;

    }
    

    void Update()
    {

        animator.SetFloat("MoveSpeed",0.1f); // diff.magnitudeでやりたいけどできないからとりあえず数値で

        MoveByArrowKey();
    }


    private void LateUpdate()
    {
        latestPosition = transform.position;
    }


}
