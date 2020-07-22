// K.Joudo. 2020

using System.Net.Sockets;
using UnityEngine;

// シマウマの処理をするクラス
// 範囲攻撃の実装対象
public class Giraffe : Animal
{
    //RangeAttaker my_range_attack;
    protected override void Awake()
    {
        status = new Status(150, 25, 10, 1.5f, 1000, "キリン");
        base.Awake();

        GameObject obj = transform.GetChild(0).gameObject;
        my_renderer = obj.GetComponent<Renderer>();
        anim = obj.GetComponent<Animator>();
    }

    /// <summary>
    /// 範囲攻撃に上書き
    /// </summary>
    protected override void Attack()
    {
        // キリンは当たり変更を別にするためここでは上書きして何もしなくする
    }
}
