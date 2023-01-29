using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{

    public float damage;

    private void Start()
    {
        damage = 150.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!");
    }

}
