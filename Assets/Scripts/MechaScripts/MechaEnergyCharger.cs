using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerのエナジーをMAXに回復するメカ
public class MechaEnergyCharger : MechaBase
{

    // Playerを取得
    [SerializeField] private GameObject player;


    void Start()
    {

        // PlayerのエナジーをMAXに
        player.GetComponent<Player1Controller>().currentEnergy = player.GetComponent<Player1Controller>().grossEnergy;

    }


}
