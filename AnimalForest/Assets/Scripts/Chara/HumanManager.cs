// K.Joud. 2020
using UnityEngine;
using System.Collections.Generic;
// 人間を管理するクラス
public class HumanManager : SingletonMonoBehaviour<HumanManager>
{
    List<GameObject> humans = new List<GameObject>();

    public int Counter {private get; set; }

    protected override void Awake()
    {
        base.Awake();
        Counter = 0;
    }

    void Update()
    {
        // TODO リストに人間を追加する処理を書く

        // ここでループを回すのは非効率なので別の方法を考える
        // 今はとりあえずここに置いとく
        // キャラクターが死んだらリストからも除外
        //for(int i = humans.Count - 1; i >= 0; i--)
        //{
        //    if(humans[i].type == Charactor.AnimaionType.death)
        //    {
        //        humans.RemoveAt(i);
        //    }
        //}
    }

    /// <summary>
    /// 一番近い人間を探す(自分の座標）
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject SearchNearHuman(Vector3 position)
    {
        int count = 0;
        float dis = Vector3.Distance(position, humans[0].transform.position);
        for(int i = 1; i < humans.Count; i++)
        {
            float d = Vector3.Distance(position, humans[i].transform.position);
            if(dis > d)
            {
                count = i;
            }
        }

        return humans[count];
    }
}
