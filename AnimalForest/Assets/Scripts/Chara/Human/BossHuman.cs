// K.Joudo. 2020

// クマの処理をするクラス
public class BossHuman : Human
{
    protected override void Awake()
    {
        status = new Status(2000, 45, 10, 0.5f, 0, "BOSS");
        base.Awake();
    }
}
