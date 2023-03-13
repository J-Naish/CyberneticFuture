using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// カメラの方向に向けさせるクラス
public class LookAtCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        // カメラの方を向けさせる
        transform.rotation = Camera.main.transform.rotation;
    }
}
