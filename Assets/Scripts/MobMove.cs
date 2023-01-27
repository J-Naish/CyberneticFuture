using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]


public class MobMove : MonoBehaviour
{

    private NavMeshAgent roboAgent;


    void Start()
    {
        roboAgent = GetComponent<NavMeshAgent>();
    }


    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            roboAgent.destination = collider.transform.position;
            roboAgent.transform.LookAt(collider.transform.position);
        }
    }
}