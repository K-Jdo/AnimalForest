// K.Joudo 2020

// 大人間のクラス

public class BigHuman : Human
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(800, 40, 5, 1.0f, 50, "大人間");
        SetSpeed(status.speed);
    }
}
