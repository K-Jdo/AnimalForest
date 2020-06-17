// K.Joudo 2020

// ブタのクラス
public class Pig : Animal
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(50.0f, 20.0f, 0.0f, 1.0f, 50, "ブタ");
        SetSpeed(status.speed);
    }
}
