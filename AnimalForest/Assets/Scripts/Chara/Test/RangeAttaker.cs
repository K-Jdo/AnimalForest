// K.Joudo 2020

using System.Collections.Generic;
using UnityEngine;
// 範囲攻撃のテスト

public class RangeAttaker : Human
{

    protected override void Awake()
    {
        base.Awake();
        // とりあえず小人間のデータ
        status = new Status(250, 20, 0, 1, 50, "範囲攻撃者");
        SetSpeed(status.speed);

    }
}
