// K.Joud. 2020
using UnityEngine;
using System.Collections.Generic;
// 人間を管理するクラス
public class HumanManager : SingletonMonoBehaviour<HumanManager>
{
    List<GameObject> humans = new List<GameObject>();

    public bool Is_spawn { get; private set; }
    public bool Boss_spwan { get; set; }
    public bool Boss_check { get; set; }

    public int kill_count;

    [SerializeField] int max = 5;
    const int MAX_ENEMY = 30;
    int enemy_count = 0;

    protected override void Awake()
    {
        base.Awake();
        Is_spawn = true;
        Boss_spwan = false;
        Boss_check = true;
        kill_count = 0;
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

        // 残りの敵が一定数を下回るとボスが出現
        if (MAX_ENEMY - enemy_count <= 5)
        {
            Boss_spwan = true;
        }

        // 敵の数が上限に達すると湧かなくなる
        if(enemy_count >= MAX_ENEMY)
        {
            Is_spawn = false;
            return;
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
        enemy_count++;
    }

    public int GetHumanCount() { return humans.Count; }
}
