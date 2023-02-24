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


    // 範囲内にいるかどうかを検知するbool値
    public bool isInArea = false;


    private void Start()
    {

        // ロボの初期位置を取得
        roboAgent = GameObject.Find("MobRobot");
        roboAgentNMA = roboAgent.GetComponent<NavMeshAgent>();
        originalPosition = roboAgent.transform.position;


    }


    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            isInArea = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            roboAgentNMA.destination = originalPosition;
            isInArea = false;
        }
    }


    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }

}