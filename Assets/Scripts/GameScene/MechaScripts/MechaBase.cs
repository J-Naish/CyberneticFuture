using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// メカの基底クラス
public class MechaBase : MonoBehaviour
{

    // 効果持続持続時間に関する変数
    protected float duration;
    protected float currentTime = 0f;


    // ※Prefabが生成されたことを検知するbool値
    public bool isPrefabGenerated = false;

}
