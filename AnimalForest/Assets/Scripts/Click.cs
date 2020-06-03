// S.T.
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Click : MonoBehaviour
{
    //複製したいものを入れる
    public GameObject obj;
    //クリックされたオブジェクトを入れる
    GameObject clicked_object;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    void OnClick()
    {
        //スクリーンから見たマウスの座標を得る
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //クリックされた座標を格納する
        RaycastHit hit;

        //レイヤーにrayが当たっていたら
        if (Physics.Raycast(ray, out hit))
        {   
            //クリックされた座標
            Vector3 pos = hit.point;
            //クリックされたゲームオブジェクト
            clicked_object = hit.collider.gameObject;
            //クリックされたものが指定されたレイヤーなら
            if (clicked_object.layer == 8)
            {
                //オブジェクトを複製
                Instantiate(obj, pos, Quaternion.identity);
            }
        }
    }
}
