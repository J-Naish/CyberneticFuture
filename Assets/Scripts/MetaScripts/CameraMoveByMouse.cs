using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveByMouse : MonoBehaviour
{
    //メインカメラを取得
    [SerializeField] private GameObject mainCamera;

    // Playerを取得
    [SerializeField] private GameObject playerObject;

    // 回転の速さ
    public float rotateSpeed = 0.2f;


    void Update()
    {
        rotateCamera();
    }

    //カメラを回転させる関数
    private void rotateCamera()
    {
        // Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        // メインカメラを回転させる
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);
    }
}