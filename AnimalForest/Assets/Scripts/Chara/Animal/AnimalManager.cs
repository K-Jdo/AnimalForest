// K.Joudo. 2020
using UnityEngine;
using System.Collections.Generic;

public class AnimalManager : SingletonMonoBehaviour<AnimalManager>
{
    public int Counter { private get; set; }
    List<GameObject> animals = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        // キャラクターが死んだらリストからも除外
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i] == null)
            {
                animals.RemoveAt(i);
            }
        }
    }

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
