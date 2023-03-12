using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// パーティクルが衝突した時の処理に関するクラス
public class ParticleCollision : MonoBehaviour
{

    // ダメージを定義
    //private float damage = 1.0f;

    //// パーティクルを宣言
    //private ParticleSystem ps;

    //// Enterで発動するパーティクルをリストに格納
    //List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();


    //private void OnEnable()
    //{
    //    // パーティクルシステムを取得
    //    ps = GetComponent<ParticleSystem>();
    //}


    //private void OnParticleTrigger(GameObject other)
    //{


    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    foreach (ParticleSystem.Particle particle in enter)
    //    {
    //        Collider collider = player.GetComponent<Collider>();

    //        if (collider.bounds.Contains(particle.position))
    //        {
    //            player.GetComponent<Player1Controller>().currentLife -= damage;
    //            player.GetComponent<Player1Controller>().animator.SetTrigger("Hindered");
    //        }
    //    }

    //    ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

    //}

    

}
