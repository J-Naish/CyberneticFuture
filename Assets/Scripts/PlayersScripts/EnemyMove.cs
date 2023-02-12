using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// 敵の挙動に関するクラス
public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent enemyAgent;


    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    

    public void OnDetectPlayer(Collider collider)
    {

        // 衝突対象がPlayerの場合のみPlayerに近づく
        if (collider.CompareTag("Player"))
        {
            // 一定距離までしか近づかない
            if (Vector3.Distance(collider.transform.position, this.transform.position) >= 20.0f)
            {
                enemyAgent.destination = collider.transform.position;
            }
            else if(Vector3.Distance(collider.transform.position, this.transform.position) < 20.0f)
            {
                enemyAgent.destination = this.transform.position;
            }
            enemyAgent.transform.LookAt(collider.transform.position);
        }

    }


}
