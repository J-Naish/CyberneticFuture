using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobMove : MonoBehaviour
{

    
    // public Transform target;
    private NavMeshAgent roboAgent;

    void Start()
    {
        // Agentを取得
        roboAgent = GetComponent<NavMeshAgent>();
    }

    // 衝突で追いかける仕様に変更のためコメントアウト
    //void Update()
    //{
    //    roboAgent.SetDestination(target.position);
    //}

    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // 衝突対象を向く
            transform.LookAt(collider.transform.position);
            // 衝突対象に向かう
            roboAgent.destination = collider.transform.position;            
        }
    }

}
