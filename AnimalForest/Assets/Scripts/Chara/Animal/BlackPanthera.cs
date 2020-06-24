// K.Joudo. 2020

// クロヒョウのクラス
public class BlackPanthera : Animal
{ 
    protected override void Awake()
    {
        base.Awake();
        status = new Status(80, 30, 5, 2.0f, 100, "クロヒョウ");
        SetSpeed(status.speed);
    }

}
