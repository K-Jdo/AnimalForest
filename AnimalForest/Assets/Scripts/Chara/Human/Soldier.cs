// K.Joudo 2020

// 兵士のクラス
public class Soldier : Human
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(250.0f, 20.0f, 0.0f, 20.0f, 50, "小人間");
        agent.speed = status.speed;
    }
}
