// J.K. 2020

// 動物に共通する動作を制御するクラス
public class Animal : Charactor
{
    protected override void Start()
    {
        base.Start();
        target = HumanManager.Instance.SearchNearHuman(transform.position);
    }
}
