// K.Joudo 2020

// ブタのクラス
public class Pig : Animal
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(90.0f, 15.0f, 15.0f, 1.0f, 300, "ブタ");
        SetSpeed(status.speed);
    }
}
