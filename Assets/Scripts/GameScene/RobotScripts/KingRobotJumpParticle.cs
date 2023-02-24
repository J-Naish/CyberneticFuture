using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キングロボットがジャンプして着地した後の衝撃波に関するクラス
public class KingRobotJumpParticle : MonoBehaviour
{

    // パーティクルを削除するための時間変数
    private float currentTimeDelete = 0f;
    private float deleteTime = 4.0f;


    // パーティクルを拡大させるための時間変数
    private float currentTimeExpand = 0f;
    private float expandTime = 3.0f;

    // パーティクルの拡大の度合いの変数
    private float scaleupParameter = 0.03f;


    void Update()
    {
        DeleteParticle();


        ExpandParticle();
    }


    private void DeleteParticle()
    {
        currentTimeDelete += Time.deltaTime;

        if(currentTimeDelete >= deleteTime)
        {
            Destroy(this.gameObject);
        }
    }


    private void ExpandParticle()
    {
        currentTimeExpand += Time.deltaTime;

        if(currentTimeExpand <= expandTime)
        {
            transform.localScale += new Vector3(scaleupParameter, scaleupParameter, scaleupParameter);
        }

    }

}
