using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// SelectSceneで選んだ武器を有効化するクラス
public class WeaponManager : MonoBehaviour
{

    // 武器を取得
    [SerializeField] private GameObject[] weapons = new GameObject[3];


    // どの武器が選択されたか取得
    [SerializeField] private WeaponSelectData weaponSelectData;




    private void Awake()
    {
        ActivateSelectedWeapon();
    }



    // 選択された武器を有効化
    private void ActivateSelectedWeapon()
    {
        if(weaponSelectData.weaponNumber == 1)
        {
            weapons[0].SetActive(true);
        }
        else if(weaponSelectData.weaponNumber == 2)
        {
            weapons[1].SetActive(true);
        }
        else if(weaponSelectData.weaponNumber == 3)
        {
            weapons[2].SetActive(true);
        }
    }


}
