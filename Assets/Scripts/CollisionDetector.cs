using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;



[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{


    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();


    // ロボの初期位置を取得するための宣言
    private GameObject roboAgent;
    private NavMeshAgent roboAgentNMA;
    private Vector3 originalPosition;


    private void Start()
    {

        // ロボの初期位置を取得
        roboAgent = GameObject.Find("RoboAgent");
        roboAgentNMA = roboAgent.GetComponent<NavMeshAgent>();
        originalPosition = roboAgent.transform.position;


    }


    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roboAgentNMA.destination = originalPosition;
        }
    }


    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }

}