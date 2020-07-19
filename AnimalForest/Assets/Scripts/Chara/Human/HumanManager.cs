// K.Joud. 2020
using UnityEngine;
using System.Collections.Generic;
// 人間を管理するクラス
public class HumanManager : SingletonMonoBehaviour<HumanManager>
{
    [SerializeField] GameObject[] test_objects = default;       // テスト用に初期配置するための
    List<GameObject> humans = new List<GameObject>();
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
        // 初期配置はなしのなのでテスト用
        foreach (GameObject obj in test_objects)
        {
            humans.Add(obj);
        }
    }

    private void Update()
    {
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
    /// 引数の座標から管理しているなかで一番近いオブジェクトを返す(自分の座標）
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject SearchNearObject(Vector3 position)
    {
        if (humans.Count <= 0)
        {
            return null;
        }

        // キャラクターが死んだらリストからも除外
        for (int i = humans.Count - 1; i >= 0; i--)
        {
            if (humans[i] == null)
            {
                humans.RemoveAt(i);
            }
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
    /// <param name="obj"></param>
    public void SetObject(GameObject obj)
    {
        humans.Add(obj);
    }
}
