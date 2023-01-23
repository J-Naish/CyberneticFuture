using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent roboAgent;

    void Start()
    {
        // Agentを取得
        roboAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        roboAgent.SetDestination(target.position);
    }
}
