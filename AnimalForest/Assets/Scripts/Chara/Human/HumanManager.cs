// K.Joud. 2020
using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal;
// 人間を管理するクラス
public class HumanManager : SingletonMonoBehaviour<HumanManager>
{
    [SerializeField] GameObject[] test_objects = default;       // テスト用に初期配置するための
    List<GameObject> humans = new List<GameObject>();

    [SerializeField] GameObject time;
    TimeManager time_manager;

    public bool Is_spawn { get; private set; }
    public bool Boss_spwan { get; set; }
    public bool Boss_check { get; set; }

    public int kill_count;

    [SerializeField] int max = 5;

    protected override void Awake()
    {
        base.Awake();
        time_manager = time.GetComponent<TimeManager>();
        Is_spawn = true;
        Boss_spwan = false;
        Boss_check = true;
        kill_count = 0;
        // 初期配置のやつら
        // 初期配置はなしのなのでテスト用
        foreach (GameObject obj in test_objects)
        {
            humans.Add(obj);
        }
    }

    private void Update()
    {
        for(int i = 0; i < humans.Count; i++)
        {
            if(humans[i] == null)
            {
                humans.RemoveAt(i);
            }
        }

        // 人間が湧く上限
        if (humans.Count > max - 1)
        {
            Is_spawn = false;
        }
        else
        {
            Is_spawn = true;
        }

        // 4分を過ぎるとボスが出現
        if (time_manager.GetMinute() >= 4)
        {
            Boss_spwan = true;
        }
    }

    /// <summary>
    /// 引数の座標から管理しているなかで一番近いオブジェクトを返す(自分の座標）
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject SearchNearObject(Vector3 position)
    {

        // キャラクターが死んだらリストからも除外
        for (int i = humans.Count - 1; i >= 0; i--)
        {
            if (humans[i] == null)
            {
                humans.RemoveAt(i);
            }
        }
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
    /// <param name="obj"></param>
    public void SetObject(GameObject obj)
    {
        humans.Add(obj);
    }

    public int GetHumanCount() { return humans.Count; }
}
