// K.Joudo. 2020

// クマの処理をするクラス
public class Bear : Animal
{
    protected override void Start()
    {
        base.Start();
        // ステータスは仮の値
        status = new Status(200.0f, 50.0f, 20.0f, 50.0f, 20);
    }

    protected override void Update()
    {
        base.Update();
        ChangeTarget();
    }
}
