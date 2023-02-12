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
            enemyAgent.destination = collider.transform.position;
            enemyAgent.transform.LookAt(collider.transform.position);
        }

    }


}
