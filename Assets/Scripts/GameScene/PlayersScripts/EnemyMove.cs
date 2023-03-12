using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// 敵の挙動に関するクラス
public class EnemyMove : MonoBehaviour
{
    // EnemyのNavmeshを宣言
    private NavMeshAgent enemyAgent;

    // Pleyerとの距離を測る変数
    public float distance;

    // Playerを取得
    [SerializeField] private GameObject player;


    // Playerまで近づく距離
    private float minimumDistanceToApproach = 20.0f;



    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        // distanceを定義
        distance = Vector3.Distance(player.transform.position, this.transform.position);

    }



    public void OnDetectPlayer(Collider collider)
    {

        // 衝突対象がPlayerの場合のみPlayerに近づく
        if (collider.CompareTag("Player"))
        {

            // 一定距離までしか近づかない
            if (distance >= minimumDistanceToApproach)
            {
                enemyAgent.destination = collider.transform.position;
            }
            else if(distance < minimumDistanceToApproach)
            {
                enemyAgent.destination = this.transform.position;
            }
            enemyAgent.transform.LookAt(collider.transform.position);
        }

    }


}
