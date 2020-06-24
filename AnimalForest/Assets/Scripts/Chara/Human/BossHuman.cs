// K.Joudo. 2020

// クマの処理をするクラス
public class BossHuman : Human
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(2000, 80, 10, 0.5f, 0, "BOSS");
        SetSpeed(status.speed);
    }
}
