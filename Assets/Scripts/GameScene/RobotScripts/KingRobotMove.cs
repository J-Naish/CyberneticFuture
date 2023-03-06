using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キングロボットの挙動に関するクラス
public class KingRobotMove : MonoBehaviour
{

    // 時間変数
    private float currentTimeLook = 0f;
    private float spanLook = 5.0f;

    // 範囲内にいるキャラを格納するList
    List<GameObject> playerList = new List<GameObject>();


    // 範囲内にキャラがいることを検知するbool値
    public bool playerIsInArea = false;


    // ターゲットを格納する変数
    private GameObject targetPlayer;


    // 乱数を一度だけ生成するための変数
    private bool isAlradyGenerated = false;
    private int randomNumber;


    // キングロボットの位置ベクトル取得
    private Vector3 kingRobotPosition;


    private void Start()
    {
        // キングロボットの位置ベクトル取得
        kingRobotPosition = transform.position;
    }


    private void Update()
    {
        LookAtTarget();
    }



    // 範囲内にいるキャラを取得
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            // 範囲内にいるキャラを取得
            playerList.Add(other.gameObject);
        }
    }


    // 範囲内にキャラがいる事を検知
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            playerIsInArea = true;
        }
    }


    // 範囲内にキャラがいないことを検知
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            playerIsInArea = false;
            playerList.Remove(other.gameObject);
        }
    }



    // キングロボットの挙動に関する関数
    private void LookAtTarget()
    {
        if (playerIsInArea)
        {
            // 時間計測開始
            currentTimeLook += Time.deltaTime;

            // 一定期間の間あるキャラを向く
            if(currentTimeLook <= spanLook)
            {
                // ターゲットを確定
                ChooseTargetInRandom();

                // 向く方向を定義
                // キングロボットが下向きに屈まないようにYだけ自身のY座標に
                Vector3 lookingPosition =
                    new Vector3(targetPlayer.transform.position.x, kingRobotPosition.y, targetPlayer.transform.position.z);

                transform.LookAt(lookingPosition);
            }
            if(currentTimeLook > spanLook)
            {
                // 再度ターゲットを定めるようにする
                isAlradyGenerated = false;
                currentTimeLook = 0f;
            }
        }


    }



    private void ChooseTargetInRandom()
    {
        if (!isAlradyGenerated)
        {
            // 乱数を生成してターゲットを確定
            randomNumber = Random.Range(0, playerList.Count);
            targetPlayer = playerList[randomNumber];

            // 乱数生成を検知
            isAlradyGenerated = true;
        }
    }



}
