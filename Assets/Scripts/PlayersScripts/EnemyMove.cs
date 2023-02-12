using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// 敵の挙動に関するクラス
public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent enemyAgent;

    // Pleyerとの距離を測る変数
    public float distance;


    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    

    public void OnDetectPlayer(Collider collider)
    {

        // 衝突対象がPlayerの場合のみPlayerに近づく
        if (collider.CompareTag("Player"))
        {

            // distanceを定義
            distance = Vector3.Distance(collider.transform.position, this.transform.position);

            // 一定距離までしか近づかない
            if (distance >= 20.0f)
            {
                enemyAgent.destination = collider.transform.position;
            }
            else if(distance < 20.0f)
            {
                enemyAgent.destination = this.transform.position;
            }
            enemyAgent.transform.LookAt(collider.transform.position);
        }

    }


}
