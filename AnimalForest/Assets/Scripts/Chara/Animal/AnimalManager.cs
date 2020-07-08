﻿// K.Joudo. 2020
using UnityEngine;
using System.Collections.Generic;

public class AnimalManager : SingletonMonoBehaviour<AnimalManager>
{
    public int Counter {private get; set; }
    [SerializeField] private GameObject[] objects = default;
    List<GameObject> animals = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
        // デバッグ用に入れてある必要がなくなったら消す
        //animals.Add(obj);
        foreach (GameObject obj in objects)
        {
            animals.Add(obj);
        }
    }

    //private void Update()
    //{
    //    // TODO リストに動物が生成されるたびに追加する処理を書く
    //}

    /// <summary>
    /// 引数の座標から管理しているなかで一番近いオブジェクトを返す(自分の座標）
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject SearchNearObject(Vector3 position)
    {
        if (animals.Count <= 0)
        {
            return null;
        }

        // キャラクターが死んだらリストからも除外
        for (int i = animals.Count - 1; i >= 0; i--)
        {
            if (animals[i] == null)
            {
                animals.RemoveAt(i);
            }
        }

        int count = 0;
        float dis = Vector3.Distance(position, animals[0].transform.position);
        for (int i = 1; i < animals.Count; i++)
        {
            float d = Vector3.Distance(position, animals[i].transform.position);
            if (dis > d)
            {
                count = i;
            }
        }

        return animals[count];
    }


    public void SetAnimal(GameObject obj)
    {
        animals.Add(obj);
    }
}
