using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ミニマップに表示されるロボットのCubeに関するクラス
public class RobotMiniMapCube : MonoBehaviour
{

    // 誰がロボットをキルしたかを表すbool値
    public bool killerIsPlayer = false;
    public bool killerIsEnemy = false;


    // Cubeを状況に応じて破壊する処理
    private void OnTriggerStay(Collider other)
    {

        if (killerIsEnemy && other.CompareTag("Player"))
        {
            Destroy(transform.root.gameObject);
        }
        if (killerIsPlayer)
        {
            Destroy(transform.root.gameObject);
        }

    }

}
