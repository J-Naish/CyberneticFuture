using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject bullet;
    public float bulletSpeed;

    private string objName;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        objName = collision.gameObject.name;
        Debug.Log(objName);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Hit!");
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return)) // 2/n 暫定的にエンターボタンで発射
        {
            GameObject Bullet =
                Instantiate(bullet, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * bulletSpeed);
            Destroy(Bullet, 3.0f);
        }




    }
}