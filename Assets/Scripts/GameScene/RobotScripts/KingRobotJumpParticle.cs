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



    void Update()
    {
        DeleteParticle();

        ExpandParticle();
    }



    // 時間が経てばパーティクルを破壊するクラス
    private void DeleteParticle()
    {
        currentTimeDelete += Time.deltaTime;

        if(currentTimeDelete >= deleteTime)
        {
            Destroy(this.gameObject);
        }
    }


    // パーティクルが広がっていくクラス
    private void ExpandParticle()
    {
        currentTimeExpand += Time.deltaTime;

        if(currentTimeExpand <= deleteTime)
        {
            transform.localScale += new Vector3(scaleupParameter, scaleupParameter, scaleupParameter);
        }

    }


}
