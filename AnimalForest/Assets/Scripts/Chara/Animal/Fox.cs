// K.Joudo 2020
using UnityEngine;
// 狐のクラス
public class Fox : Animal
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(50.0f, 20.0f, 0.0f, 3.0f, 50, "キツネ");
        SetSpeed(status.speed);
    }
}
