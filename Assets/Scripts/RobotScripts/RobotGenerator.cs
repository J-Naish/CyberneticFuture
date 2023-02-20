using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ロボットを生成するクラス
public class RobotGenerator : MonoBehaviour
{

    // Prefabを生成させる位置を決めるためのオブジェクト取得
    [SerializeField] private GameObject rangeX1;
    [SerializeField] private GameObject rangeX2;
    [SerializeField] private GameObject rangeZ1;
    [SerializeField] private GameObject rangeZ2;


    // 生成するモブロボットを取得
    [SerializeField] private GameObject mobRobotPrefab;


    // 一定時間ごとに生成するための時間に関する変数
    private float currentTime = 0f;


    // Prefab生成のスパンと個数を定義
    private float span = 30.0f;
    private int generatingNumber = 10;


    private void Update()
    {
        // モブロボットを10個10秒おきに生成
        CreateRobotPrefab(span, generatingNumber, mobRobotPrefab);

    }


    // span時間おきにnumber個のrobotを生成する関数
    private void CreateRobotPrefab(float t,int n,GameObject robot)
    {
        // 時間計測開始
        currentTime += Time.deltaTime;


        // span秒経過したらPrefab生成
        if (currentTime >= t)
        {

            for (int i = 0; i < n; i++)
            {
                // 生成する範囲を定義
                float x = Random.Range(rangeX1.transform.position.x, rangeX2.transform.position.x);
                float y = 248.5f; // 地面のY座標
                float z = Random.Range(rangeZ1.transform.position.z, rangeZ2.transform.position.z);

                // robotをPrefab化
                Instantiate(robot, new Vector3(x, y, z), robot.transform.rotation);
            }

            // 時間をリセット
            currentTime = 0f;

        }
    }


}
