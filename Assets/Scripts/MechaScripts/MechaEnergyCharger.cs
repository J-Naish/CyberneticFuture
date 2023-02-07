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


    void Start()
    {

        this.gameObject.GetComponent<MechaEnergyCharger>().enabled = false;

        // 初期はfalse
        isAlreadyCharged = false;

    }


    private void Update()
    {

        if (!isAlreadyCharged)
        {

            // PlayerのエナジーをMAXに
            player.GetComponent<Player1Controller>().currentEnergy = player.GetComponent<Player1Controller>().grossEnergy;

            // bool値を更新
            isAlreadyCharged = true;

        }
    }


}
