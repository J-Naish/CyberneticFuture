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
    private float mobCurrentTime = 0f;


    // MobPrefab生成のスパンと個数を定義
    private float mobSpan = 30.0f;
    private int mobGeneratingNumber = 10;



    // KingRobotを取得
    [SerializeField] private GameObject kingRobot;

    // 一定時間ごとに生成するための時間に関する変数
    private float kingCurrentTime = 0f;

    // MobPrefab生成のスパンと個数を定義
    private float kingSpan = 120.0f;

    // KinRobotを生成する位置取得
    [SerializeField] private GameObject centerObject;



    private void Update()
    {
        // モブロボットを10個30秒おきに生成
        CreateMobRobotPrefab(mobSpan,mobGeneratingNumber, mobRobotPrefab);

        // キングロボットを生成
        CreateKingRobotPrefab(kingSpan, kingRobot);
    }



    // t時間おきにnr個のMobRobotを生成する関数
    private void CreateMobRobotPrefab(float t,int n,GameObject robot)
    {
        // 時間計測開始
        mobCurrentTime += Time.deltaTime;


        // span秒経過したらPrefab生成
        if (mobCurrentTime >= t)
        {
            for (int i = 0; i < n; i++)
            {
                // robotをPrefab化
                Instantiate(robot,GetRandomVector3(), robot.transform.rotation);
            }

            // 時間をリセット
            mobCurrentTime = 0f;

        }
    }



    // ランダムな位置を取得する関数
    private Vector3 GetRandomVector3()
    {
        Vector3 randomVector3;
        randomVector3.x = Random.Range(rangeX1.transform.position.x, rangeX2.transform.position.x);
        randomVector3.y = 248.5f;
        randomVector3.z = Random.Range(rangeZ1.transform.position.z, rangeZ2.transform.position.z);
        return randomVector3;
    }



    // t時間おきにRobotを生成する関数
    private void CreateKingRobotPrefab(float t, GameObject robot)
    {
        // 時間計測開始
        kingCurrentTime += Time.deltaTime;


        // span秒経過したらPrefab生成
        if (kingCurrentTime >= t)
        {

            // robotをPrefab化
            Instantiate(robot, centerObject.transform.position, robot.transform.rotation);

            // 時間をリセット
            kingCurrentTime = 0f;

        }
    }




}
