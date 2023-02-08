using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerのエナジーをMAXに回復するメカ
public class MechaEnergyCharger : MechaBase
{

    // Playerを取得
    [SerializeField] private GameObject player;


    // 処理を一度だけ起こすためのbool値
    private bool isAlreadyCharged;


    // メカ使用を検知するためのオブジェクト取得
    [SerializeField] private GameObject mechaUse;


    void Start()
    {

        // 初期はfalse
        isAlreadyCharged = false;

    }


    private void Update()
    {
        // ※
        if (isPrefabGenerated)
        {
            if (mechaUse.GetComponent<MechaUse>().useMecha)
            {

                if (!isAlreadyCharged)
                {

                    // PlayerのエナジーをMAXに
                    player.GetComponent<Player1Controller>().currentEnergy = player.GetComponent<Player1Controller>().grossEnergy;

                    // bool値を更新
                    isAlreadyCharged = true;

                }

                // メカ使用後はfalseに戻す
                mechaUse.GetComponent<MechaUse>().useMecha = false;

                // 使用後はisPrefabGeneratedをfalseに戻す
                isPrefabGenerated = false;

                // メカ使用後はプレファブ化されたものを破壊
                Destroy(this.gameObject);
            }
        }

    }


}
