// K.Joudo 2020

// 兵士のクラス
public class Soldier : Human
{
    protected override void Awake()
    {
        status = new Status(250, 20, 0, 1.0f, 50, "小人間");
        base.Awake();
    }
}
