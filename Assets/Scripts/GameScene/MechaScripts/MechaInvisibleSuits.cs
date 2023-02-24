//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//// Playerを透明にするメカ
//public class MechaInvisibleSuits : MechaBase
//{

//    // Playerを取得
//    [SerializeField] private GameObject player;



//    private void Start()
//    {

//        // 持続時間を設定
//        duration = 10.0f;

//    }


//    void Update()
//    {

//        currentTime += Time.deltaTime;

//        // 一定時間透明になる
//        if(currentTime < duration)
//        {

//            BecomeTransparent(player.GetComponent<MeshRenderer>());

//        }


//    }


//    // 透明にする関数
//    private void BecomeTransparent(MeshRenderer m)
//    {
//        var c = m.material.color;
//        m.material.color = new Color(c.r, c.g, c.b, 0);
//    }

//}
