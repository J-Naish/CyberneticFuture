using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// エナジーソードのSEに関するクラス
public class EnergySwordSE : MonoBehaviour
{

    // SEを取得
    [SerializeField] private AudioClip energySwordSE;

    // AudioSourceを宣言
    private AudioSource audioSource;


    // エナジーソードでの攻撃を検知するbool値
    public bool isAttacking;


    private void Start()
    {
        // AudioSorceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        SoundEnergySwordSE();
    }


    // エナジーソードのSEを起動する関数
    private void SoundEnergySwordSE()
    {
        // エナジーソードでの攻撃を検知した時のみ再生
        if (isAttacking)
        {
            // AudioSorceコンポーネントを取得
            audioSource = GetComponent<AudioSource>();

            // SEを再生
            audioSource.PlayOneShot(energySwordSE);

            // 攻撃検知変数をfalseに
            isAttacking = false;
        }
    }



}
