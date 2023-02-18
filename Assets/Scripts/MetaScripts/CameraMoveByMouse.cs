using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// マウスの移動に合わせてカメラの視点を移動させるクラス
// iPhoneで画面のスライドで移動させる
public class CameraMoveByMouse : MonoBehaviour
{

    // Playerを取得
    [SerializeField] private GameObject player;


    // マウス移動を表す変数
    private float mouseX;
    private float mouseY;


    void Update()
    {
        CameraMoveBySlide();
    }


    // マウスの移動に合わせて視点を変える関数
    private void CameraMoveBySlide()
    {
        // マウスの移動を取得
        mouseX = Input.GetAxis("Mouse X");
        mouseX = Input.GetAxis("Mouse Y");

        // 一定以上マウス移動があれば横に画面を回転
        if(Mathf.Abs(mouseX) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.up, mouseX);
        }
        if (Mathf.Abs(mouseY) > 0.001f)
        {
            transform.RotateAround(player.transform.position, Vector3.right, mouseY);
        }

    }


}
