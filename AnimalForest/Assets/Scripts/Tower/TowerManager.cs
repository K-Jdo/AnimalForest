//F.D.
//タワーのデータ構造クラス
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public int hp;
    public bool number;
    public int damage;
    public int max_hp;
    private GameObject nearObj;


    //int max_number = 5;

    //一番近いタワーを探す::動くかは不明
    //private void Update()
    //{
    //    nearObj = SerchTag(gameObject, "Tower");
    //}

    //private GameObject SerchTag(GameObject nowObj, string tagname)
    //{
    //    float templateDistance = 0;
    //    float nearDistance = 0;
    //    string nearObjName;
    //    GameObject targetObj = null;

    //    //タグ指定されたオブジェクトを配列で取得する
    //    foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagname))
    //    {
    //        //自身と取得したオブジェクトの距離を取得
    //        templateDistance = Vector3.Distance(obs.transform.position, nowObj.transform.position);

    //        //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
    //        //一時変数に距離を格納
    //        if (nearDistance == 0 || nearDistance > templateDistance)
    //        {
    //            nearDistance = templateDistance;
    //            //nearObjName = obs.name;
    //            targetObj = obs;
    //        }

    //    }
    //    //最も近かったオブジェクトを返す
    //    //return GameObject.Find(nearObjName);
    //    return targetObj;
    //}
}
