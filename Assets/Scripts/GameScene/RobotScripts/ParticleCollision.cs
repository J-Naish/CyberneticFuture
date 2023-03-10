using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// パーティクルが衝突した時の処理に関するクラス
public class ParticleCollision : MonoBehaviour
{

    // ダメージを定義
    private float damage = 1.0f;


    //private void OnParticleTrigger(GameObject other)
    //{
    //    ParticleSystem ps = GetComponent<ParticleSystem>();


    //    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    foreach(ParticleSystem.Particle particle in enter)
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
