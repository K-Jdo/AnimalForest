// K.Joudo. 2020

// クマの処理をするクラス
public class Bear : Animal
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(150.0f, 50.0f, 10.0f, 15.0f, 1000, "クマ");
        agent.speed = status.speed;
    }
}
