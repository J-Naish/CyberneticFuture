using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveByMouse : MonoBehaviour
{
    //プレイヤーを変数に格納
    [SerializeField] private GameObject player;

    //回転させるスピード
    [SerializeField] private float rotateSpeed = 3.0f;


    void Update()
    {
        CameraMoveByArrowKey();
    }


    private void CameraMoveByArrowKey()
    {
        //回転させる角度
        float angle = Input.GetAxis("Horizontal") * rotateSpeed;

        //プレイヤー位置情報
        Vector3 playerPosition = player.transform.position;

        //カメラを回転させる
        transform.RotateAround(playerPosition, Vector3.up, angle);
    }




}