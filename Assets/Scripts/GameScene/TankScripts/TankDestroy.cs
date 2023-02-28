using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 一定エナジーを超えたらタンクを破壊するクラス
public class TankDestroy : MonoBehaviour
{

    // 爆発パーティクルを取得
    [SerializeField] GameObject explosionParticle;


    private void Update()
    {
        DestroyTank();
    }


    private void DestroyTank()
    {
        if(GetComponent<TankController>().currentTankEnergy >= GetComponent<TankController>().maxEnergyCapacity)
        {
            // パーティクルを生成
            Instantiate(explosionParticle, transform.position, Quaternion.identity);

            // 破壊
            Destroy(this.gameObject);
        }

    }

}
