//F.D.
//タワークラス
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA;
using Vector3 = UnityEngine.Vector3;

public class Tower : TowerManager
{
    GameObject[] Obj;
    private TowerManager tower_manager;
    public UnityEngine.UI.Slider slider;

    void Awake()
    {
        tower_manager = GetComponent<TowerManager>();
    }

    private void Start()
    {
        //ADD  1秒毎追加(体力メーターも)
        Obj = GameObject.FindGameObjectsWithTag("Tower");
        Debug.Log("残りタワー数は :" + Obj.Length);

        hp = hp - damage;
        //ADD  現在HP(ダメージが出来たら差し替え)
        Debug.Log("Start hp : " + hp);

        //HPバー模索中
        slider.maxValue = max_hp;
        slider.value = hp;



        //transformを取得
        Transform transform = this.transform;

        Vector3 worldpos = transform.position;
        Vector3 localpos = transform.localPosition;

        Debug.Log("x："+ worldpos.x +" y：" + worldpos.y + " z：" + worldpos.z);

    }
}