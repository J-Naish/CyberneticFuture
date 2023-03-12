using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// LoginScene中のBGMに関するクラス
public class LoginBGMManager : MonoBehaviour
{
    // AudioSourceを定義
    private AudioSource audioSource;

    // Scene遷移を検知するためのゲームオブジェクト取得
    [SerializeField] private GameObject loginSceneManager;


    // 下げる音量の変数
    private float decreasingVolume = 0.05f;

    // 音量を下げる時のスパン(秒)
    private float fadingAwaySpan = 0.1f;



    void Start()
    {
        // AudioSourceを取得
        audioSource = GetComponent<AudioSource>();

        // Coroutine開始
        StartCoroutine("VolumeDown");
    }



    // BGMをフェードアウトさせるCoroutine
    IEnumerator VolumeDown()
    {
        // Enterが押されればCoroutine開始
        if (loginSceneManager.GetComponent<LoadingSceneManager>().isLodingNextScene)
        {
            while (audioSource.volume > 0)
            {
                // 0.1秒おきにボリュームを0.05下げる
                audioSource.volume -= decreasingVolume;
                yield return new WaitForSeconds(fadingAwaySpan);
            }
        }
    }

}
