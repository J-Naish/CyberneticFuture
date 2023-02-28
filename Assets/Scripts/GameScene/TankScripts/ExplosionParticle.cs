using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 爆発パーティクルに関するクラス
public class ExplosionParticle : MonoBehaviour
{

    private float currentTime = 0f;

    private float span = 1.2f;


    void Update()
    {
        ParticleDisappear();
    }


    private void ParticleDisappear()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= span)
        {
            Destroy(this.gameObject);
        }
    }

}
