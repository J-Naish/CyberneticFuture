using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 選択した武器の情報を保持させるクラス
[CreateAssetMenu]
public class WeaponSelectData : ScriptableObject
{
    // どの武器が選択されたかを示す変数
    public int weaponNumber;

}
