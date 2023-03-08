using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// メカボックスを生成するためのクラス
public class MechaBox : MonoBehaviour
{


    // Prefabを生成させる位置を決めるためのオブジェクト取得
    [SerializeField] private GameObject rangeX1;
    [SerializeField] private GameObject rangeX2;
    [SerializeField] private GameObject rangeZ1;
    [SerializeField] private GameObject rangeZ2;
    // Prefab生成の位置のY座標(地面)を定義
    private const float groundYPosition = 248.5f;


    // メカボックスのPrefabを取得
    [SerializeField] private GameObject mechaBoxPrefab;


    // メカボックスを生成する個数を定義
    private int generatingNumber = 3;


    // メカボックスが他のオブジェクトとぶつからないように出現させるための空オブジェクト
    [SerializeField] private GameObject emptyCollisionDetector;


    // 時間ごとにPrefabを生成するために時間変数を取得
    private float span = 10.0f;
    private float currentTime = 0f;


    // Prefabを出現させる座標
    private float xPosition, yPosition, zPosition;


    // 衝突検知オブジェクトを格納するリストを作成
    private List<GameObject> mechaBoxList = new List<GameObject>();


    // リストを既に生成したか検知するbool値
    private bool isAlreadyGenerated = false;


    private void Start()
    {
        
    }


    void Update()
    {
        CreateCollisionDetectorPrefab(generatingNumber);

        CreateMechaBoxPrefab();
    }


    private void LateUpdate()
    {
        DetectCollision();
    }




    // 衝突検知用の空オブジェクトを生成する関数
    private void CreateCollisionDetectorPrefab(int n)
    {
        // リストが既に生成されてたら関数を実行しない
        if (isAlreadyGenerated) return;

        for (int i = 0; i < n; i++)
        {
            // 衝突検知用の空オブジェクトを生成
            mechaBoxList.Add(Instantiate(emptyCollisionDetector, CreateRandomVector(), mechaBoxPrefab.transform.rotation));
        }

        // bool値を変更
        isAlreadyGenerated = true;
    }



    // 衝突検知オブジェクトが衝突してたら座標を変える関数
    private void DetectCollision()
    {
        // 衝突を検知して座標を変更
        for(int i = 0;i < mechaBoxList.Count; i++)
        {
            if (mechaBoxList[i].GetComponent<MechaBoxCollisionDetector>().isCollidered)
            {
                // 座標をランダムに変更
                mechaBoxList[i].transform.position = CreateRandomVector();
                // 衝突検知bool値を変更
                mechaBoxList[i].GetComponent<MechaBoxCollisionDetector>().isCollidered = false;
            }
        }

    }



    // メカボックスを生成する関数
    private void CreateMechaBoxPrefab()
    {
        // 時間を加算していく
        currentTime += Time.deltaTime;

        // 加算された時間がspanを超えたらPrefabを生成
        if (currentTime > span)
        {
            // 衝突検知した場所にPrefabを生成
            for(int i = 0;i < mechaBoxList.Count;i++)
            {
                Instantiate(mechaBoxPrefab, mechaBoxList[i].transform.position, mechaBoxPrefab.transform.rotation);
                Destroy(mechaBoxList[i]);
            }

            // リストをリセット
            mechaBoxList.Clear();

            // リストを0から作るためのbool値を更新
            isAlreadyGenerated = false;

            // 時間リセット
            currentTime = 0f;
        }
    }



    // 乱数を生成して座標を返す関数
    private Vector3 CreateRandomVector()
    {
        // 生成する範囲を乱数で定義
        xPosition = Random.Range(rangeX1.transform.position.x, rangeX2.transform.position.x);
        yPosition = groundYPosition;
        zPosition = Random.Range(rangeZ1.transform.position.z, rangeZ2.transform.position.z);

        return new Vector3(xPosition, yPosition, zPosition);
    }


}
