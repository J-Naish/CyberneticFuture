using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 武器の選択に関するクラス
// 選択されたものをゲームで使用する
public class SelectController : MonoBehaviour
{

    // 武器画像を黒くしてる画像を取得
    [SerializeField] private Image[] blackImages = new Image[3];

    // 配列にn番目の数
    private int arrayNumber;


    // Sceneをまたいで選択武器データを取得するためのもの
    [SerializeField] private WeaponSelectData weaponSelectData;


    // 武器を取得
    [SerializeField] private GameObject[] weapons = new GameObject[3];

    
    void Update()
    {
        SelectWeapon();
    }



    // 武器画像の明るさを変える関数
    private void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            arrayNumber = 1 - 1;
            DarkenUnselectedWeapons();
            ActivateSelectedWeapon();
            weaponSelectData.weaponNumber = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            arrayNumber = 2 - 1;
            DarkenUnselectedWeapons();
            ActivateSelectedWeapon();
            weaponSelectData.weaponNumber = 2;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            arrayNumber = 3 - 1;
            DarkenUnselectedWeapons();
            ActivateSelectedWeapon();
            weaponSelectData.weaponNumber = 3;
        }

    }



    // 選択武器以外を暗くする関数
    private void DarkenUnselectedWeapons()
    {
        for(int i = 0; i < blackImages.Length; i++)
        {
            blackImages[i].GetComponent<BlackImage>().isSelected = false;
            if(i == arrayNumber)
            {
                blackImages[i].GetComponent<BlackImage>().isSelected = true;
            }
        }
    }


    // 選択した武器を有効化する関数
    private void ActivateSelectedWeapon()
    {
        for(int i = 0;i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
            if(i == arrayNumber)
            {
                weapons[i].SetActive(true);
            }
        }

    }


}
