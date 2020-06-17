// K.Joud. 2020
using UnityEngine;
using System.Collections.Generic;
// 人間を管理するクラス
public class HumanManager : SingletonMonoBehaviour<HumanManager>
{
    List<GameObject> humans = new List<GameObject>();
    //[SerializeField] GameObject[] objects = default;

    // これ何に使うか忘れた
    // 特に使わんのなら消す
    //public int Counter { private get; set; }

    public bool Is_spawn { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        //Counter = 0;
        Is_spawn = true;

        // 初期配置のやつら
        // 初期配置するならいるいらないなら消す
        //foreach(GameObject obj in objects)
        //{
        //    humans.Add(obj);
        //}
    }

    void Update()
    {
        // キャラクターが死んだらリストからも除外
        for (int i = humans.Count - 1; i >= 0; i--)
        {
            if (humans[i] == null)
            {
                humans.RemoveAt(i);
            }
        }

        if (humans.Count > 2)
        {
            Is_spawn = false;
        }
        else
        {
            Is_spawn = true;
        }
    }

    /// <summary>
    /// 一番近い人間を探す(自分の座標）
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject SearchNearHuman(Vector3 position)
    {
        if (humans.Count <= 0)
        {
            return null;
        }
        int count = 0;
        float dis = Vector3.Distance(position, humans[0].transform.position);
        for (int i = 1; i < humans.Count; i++)
        {
            float d = Vector3.Distance(position, humans[i].transform.position);
            if (dis > d)
            {
                count = i;
            }
        }

        return humans[count];
    }

    /// <summary>
    /// リストにオブジェクトを追加
    /// </summary>
    /// <param name="go"></param>
    public void SetHuman(GameObject obj)
    {
        humans.Add(obj);
    }
}
