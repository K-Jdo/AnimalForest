﻿// K.Joudo. 2020

// クマの処理をするクラス
public class Bear : Animal
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(150, 50, 10, 1.5f, 1000, "クマ");
        SetSpeed(status.speed);
    }
}
