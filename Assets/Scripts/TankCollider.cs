using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCollider : MonoBehaviour
{

    [SerializeField] private Image buttonImage;


    private void Start()
    {
        buttonImage.enabled = false;
    }


    private void OnTriggerStay(Collider other)
    {
        buttonImage.enabled = true;
    }

   
}
