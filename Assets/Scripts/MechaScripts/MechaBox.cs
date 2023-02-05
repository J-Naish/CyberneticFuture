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


    // メカボックスのPrefabを取得
    [SerializeField] private GameObject mechaBoxPrefab;


    // 時間ごとにPrefabを生成するために時間変数を取得
    private float span = 60.0f;
    private float currentTime = 0f;


    
    void Update()
    {

        // 時間を加算していく
        currentTime += Time.deltaTime;

        // 加算された時間がspanを超えたらPrefabを生成
        if(currentTime > span)
        {

            // Prefabを3個生成
            CreateMechaBoxPrefab(3);

            // 時間リセット
            currentTime = 0f;
        }

    }



    // Prefabをn個生成する関数
    private void CreateMechaBoxPrefab(int n)
    {

        // prefabをn個生成するためのfor文
        for (int i = 0; i < n; i++)
        {
            // 生成する範囲を定義
            float x = Random.Range(rangeX1.transform.position.x, rangeX2.transform.position.x);
            float y = 248.5f; // 地面のY座標
            float z = Random.Range(rangeZ1.transform.position.z, rangeZ2.transform.position.z);

            // メカボックスPrefabを生成
            Instantiate(mechaBoxPrefab, new Vector3(x, y, z), mechaBoxPrefab.transform.rotation);
        }

    }


}
