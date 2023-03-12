using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// エナジーガンのSEに関するクラス
public class EnergyGunSE : MonoBehaviour
{

    // SEを取得
    [SerializeField] private AudioClip energyGunSE;

    // AudioSourceを宣言
    private AudioSource audioSource;


    private void Start()
    {
        // AudioSorceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // Start時(Prefab化された時)にSEを再生
        audioSource.PlayOneShot(energyGunSE);
    }

}
