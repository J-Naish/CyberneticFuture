using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{

    // この銃弾が与えるダメージ変数
    public float damage;



    private void Start()
    {

        // とりあえず150に設定
        damage = 150.0f;


    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!");
    }

}
