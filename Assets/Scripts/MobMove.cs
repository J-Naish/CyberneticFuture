using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]


public class MobMove : MonoBehaviour
{

    private NavMeshAgent roboAgent;
    private Vector3 firstPosition;


    void Start()
    {
        roboAgent = GetComponent<NavMeshAgent>();
        firstPosition = roboAgent.transform.position;
    }


    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            roboAgent.destination = collider.transform.position;
            roboAgent.transform.LookAt(collider.transform.position);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roboAgent.destination = firstPosition;
        }
    }

}