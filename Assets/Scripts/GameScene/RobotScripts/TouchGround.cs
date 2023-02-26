using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キングロボットの着地時にパーティクルを放出させるクラス
public class TouchGround : MonoBehaviour
{

    // パーティクルを取得
    [SerializeField] private GameObject particle;

    // パーティクルの発生場所
    [SerializeField] private GameObject particlePosition;


    // 着地したらパーティクルをPrefab化
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(particle, particlePosition.transform.position, Quaternion.Euler(-90,0,0));
            Debug.Log("ground");
        }
    }

}
