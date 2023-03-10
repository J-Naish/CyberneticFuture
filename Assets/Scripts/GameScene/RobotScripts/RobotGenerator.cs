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
    // Prefab生成の位置のY座標(地面)を定義
    private const float groundYPosition = 248.5f;


    // 生成するモブロボットを取得
    [SerializeField] private GameObject mobRobotPrefab;


    // 一定時間ごとに生成するための時間に関する変数
    private float mobCurrentTime = 0f;


    // MobPrefab生成のスパンと個数を定義
    private float mobSpan = 60.0f;
    private int mobGeneratingNumber = 10;


    // リストを既に生成したか検知するbool値
    private bool isAlreadyGenerated = false;

    // 衝突検知オブジェクトを格納するリストを作成
    private List<GameObject> collisionDetectorList = new List<GameObject>();

    // メカボックスが他のオブジェクトとぶつからないように出現させるための空オブジェクト
    [SerializeField] private GameObject emptyCollisionDetector;


    // Prefabを出現させる座標
    private float xPosition, yPosition, zPosition;



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
        // 衝突検知オブジェクトを生成
        CreateCollisionDetector(mobGeneratingNumber);

        // モブロボットを生成
        CreateMobRobotPrefab();

        // キングロボットを生成
        CreateKingRobotPrefab(kingSpan, kingRobot);
    }



    private void LateUpdate()
    {
        DetectCollision();
    }




    // t時間おきにnr個のMobRobotを生成する関数
    private void CreateMobRobotPrefab()
    {
        // 時間を加算していく
        mobCurrentTime += Time.deltaTime;

        // 加算された時間がspanを超えたらPrefabを生成
        if (mobCurrentTime > mobSpan)
        {
            // 衝突検知した場所にPrefabを生成
            for (int i = 0; i < collisionDetectorList.Count; i++)
            {
                Instantiate(mobRobotPrefab, collisionDetectorList[i].transform.position, mobRobotPrefab.transform.rotation);
                Destroy(collisionDetectorList[i]);
            }

            // リストをリセット
            collisionDetectorList.Clear();

            // リストを0から作るためのbool値を更新
            isAlreadyGenerated = false;

            // 時間リセット
            mobCurrentTime = 0f;
        }
    }



    private void CreateCollisionDetector(int n)
    {
        // リストが既に生成されてたら関数を実行しない
        if (isAlreadyGenerated) return;

        for (int i = 0; i < n; i++)
        {
            // 衝突検知用の空オブジェクトを生成
            collisionDetectorList.Add(Instantiate(emptyCollisionDetector,
                GetRandomVector3(), mobRobotPrefab.transform.rotation));
        }

        // bool値を変更
        isAlreadyGenerated = true;
    }



    // 衝突検知オブジェクトが衝突してたら座標を変える関数
    private void DetectCollision()
    {
        // 衝突を検知して座標を変更
        for (int i = 0; i < collisionDetectorList.Count; i++)
        {
            if (collisionDetectorList[i].GetComponent<MechaBoxCollisionDetector>().isCollidered)
            {
                // 座標をランダムに変更
                collisionDetectorList[i].transform.position = GetRandomVector3();
                // 衝突検知bool値を変更
                collisionDetectorList[i].GetComponent<MechaBoxCollisionDetector>().isCollidered = false;
            }
        }

    }




    // ランダムな位置を取得する関数
    private Vector3 GetRandomVector3()
    {
        // 生成する範囲を乱数で定義
        xPosition = Random.Range(rangeX1.transform.position.x, rangeX2.transform.position.x);
        yPosition = groundYPosition;
        zPosition = Random.Range(rangeZ1.transform.position.z, rangeZ2.transform.position.z);

        return new Vector3(xPosition, yPosition, zPosition);
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
