// K.Joudo. 2020
using UnityEngine;
using System.Collections.Generic;

public class AnimalManager : SingletonMonoBehaviour<AnimalManager>
{
    List<GameObject> animals = new List<GameObject>();
    public int Counter {private get; set; }
    //[SerializeField] private GameObject obj = default;

    protected override void Awake()
    {
        base.Awake();
        // デバッグ用に入れてある必要がなくなったら消す
        //animals.Add(obj);
    }

    void Update()
    {
        // TODO リストに動物が生成されるたびに追加する処理を書く
    }

    /// <summary>
    /// 一番近い動物を探す(自分の座標）
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject SearchNearAnimal(Vector3 position)
    {
        return animals[0];
        //int count = 0;
        //float dis = Vector3.Distance(position, animals[0].transform.position);
        //for (int i = 1; i < animals.Count; i++)
        //{
        //    float d = Vector3.Distance(position, animals[i].transform.position);
        //    if (dis > d)
        //    {
        //        count = i;
        //    }
        //}

        //return animals[count];
    }

}
