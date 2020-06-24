// K.Joudo 2020

// 中人間のクラス

public class MiddleHuman : Human
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(500, 25, 5, 1.0f, 50, "中人間");
        SetSpeed(status.speed);
    }
}
