// K.Joudo 2020

// レア人間のクラス
public class RareHuman : Human
{
    protected override void Awake()
    {
        status = new Status(15, 500, 15, 3.0f, 10000, "レア人間");
        base.Awake();
    }
}
