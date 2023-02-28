using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroy : MonoBehaviour
{


    private void Update()
    {
        DestroyTank();
    }


    private void DestroyTank()
    {
        if(GetComponent<TankController>().currentTankEnergy >= GetComponent<TankController>().maxEnergyCapacity)
        {
            Destroy(this.gameObject);
        }

    }

}
