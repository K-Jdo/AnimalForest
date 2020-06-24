// K.Joudo. 2020

// クロヒョウのクラス
public class BlackPanthera : Animal
{ 
    protected override void Awake()
    {
        base.Awake();
        status = new Status(80.0f, 30.0f, 5.0f, 5.0f, 100, "クロヒョウ");
        SetSpeed(status.speed);
    }

}
