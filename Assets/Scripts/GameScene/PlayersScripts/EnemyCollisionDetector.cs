using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


// Enemyの挙動に関するクラス
public class EnemyCollisionDetector : MonoBehaviour
{

    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();


    // Enemyの初期位置を取得するための変数
    [SerializeField] private GameObject enemyAgent;
    private Vector3 originalPosition;

    
    void Start()
    {
        // 元々いた場所を取得
        originalPosition = enemyAgent.transform.position;
    }



    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            enemyAgent.GetComponent<NavMeshAgent>().destination = originalPosition;
        }

    }


    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }


}
