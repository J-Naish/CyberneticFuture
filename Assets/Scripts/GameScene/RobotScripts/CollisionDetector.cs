using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


// 範囲内にキャラが近づいた事を検知するクラス
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
            // 範囲内にいる事を検知
            isInArea = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            // 範囲外にいけば元の位置に戻る
            roboAgentNMA.destination = originalPosition;
            isInArea = false;
        }
    }


    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }

}