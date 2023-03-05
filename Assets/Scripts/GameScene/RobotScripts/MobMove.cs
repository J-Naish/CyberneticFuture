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
        if (collider.CompareTag("Player") || collider.CompareTag("Enemy"))
        {
            // 一定距離まで近づく
            if (Vector3.Distance(collider.transform.position, this.gameObject.transform.position) >= 20.0f)
            {
                roboAgent.destination = collider.transform.position;
            }
            else if(Vector3.Distance(collider.transform.position, this.gameObject.transform.position) < 20.0f)
            {
                roboAgent.destination = this.gameObject.transform.position;
            }
            roboAgent.transform.LookAt(collider.transform.position);
            
        }
    }


}