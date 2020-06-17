// K.Joudo 2020

// 狐のクラス
public class Fox : Animal
{
    protected override void Awake()
    {
        base.Awake();
        status = new Status(90.0f, 15.0f, 15.0f, 3.0f, 300, "キツネ");
        SetSpeed(status.speed);
    }
}
