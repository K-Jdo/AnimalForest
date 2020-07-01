// K.Joudo 2020
using UnityEngine;
// 狐のクラス
public class Fox : Animal
{
    protected override void Awake()
    {
        status = new Status(50, 20, 0, 1.5f, 50, "キツネ");
        base.Awake();
    }
}
