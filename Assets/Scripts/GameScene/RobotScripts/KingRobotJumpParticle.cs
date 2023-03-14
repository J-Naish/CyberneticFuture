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

    // パーティクルの拡大の度合いの変数
    private float scaleupParameter = 0.03f;

    // パーティクルの上昇量
    private Vector3 raisingVector = new Vector3(0, 0.001f, 0);



    void Update()
    {
        DeleteParticle();

        ExpandParticle();

        RaiseParticle();
    }



    // 時間が経てばパーティクルを破壊する関数
    private void DeleteParticle()
    {
        currentTimeDelete += Time.deltaTime;

        if(currentTimeDelete >= deleteTime)
        {
            Destroy(this.gameObject);
        }
    }


    // パーティクルが広がっていく関数
    private void ExpandParticle()
    {
        currentTimeExpand += Time.deltaTime;

        if(currentTimeExpand <= deleteTime)
        {
            transform.localScale += new Vector3(scaleupParameter, scaleupParameter, scaleupParameter);
        }
    }


    // パーティクルを上昇させる関数
    private void RaiseParticle()
    {
        transform.position += raisingVector;
    }


}
