//F.D.
//タワークラス
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower : TowerManager
{
    GameObject[] Obj;
    private TowerManager TM;


    void Awake()
    {
        TM = GetComponent<TowerManager>();
    }

    private void Start()
    {
        hp = TM.max_hp - TM.damage;
        //現在HP(ダメージが出来たら差し替え)
        Debug.Log("Start hp : " + hp);

        //1秒毎追加(体力メーターも)
        Obj = GameObject.FindGameObjectsWithTag("Tower");
        Debug.Log("残りタワー数は :" +Obj.Length);
    }
}
