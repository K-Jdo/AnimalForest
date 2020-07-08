// K.Joudo 2020

// ブタのクラス
public class Pig : Animal
{
    protected override void Awake()
    {
        status = new Status(90, 15, 15, 1.0f, 300, "ブタ");
        base.Awake();
    }
}
