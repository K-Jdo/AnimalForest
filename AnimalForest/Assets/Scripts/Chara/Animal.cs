// K.Joudo. 2020

// 動物に共通する動作を制御するクラス
public class Animal : Character
{
    protected override void Start()
    {
        base.Start();
        target = HumanManager.Instance.SearchNearHuman(transform.position);
    }

    protected override void ChangeTarget()
    {
        //throw new System.NotImplementedException();

        if(target == null)
        {
            // 敵を撃破すると次の敵を探す
            type = AnimaionType.walk;
            target = HumanManager.Instance.SearchNearHuman(transform.position);
        }
        else if(type == AnimaionType.damage)
        {
            // 攻撃を受けたので反撃する
            type = AnimaionType.attack;
            target = HumanManager.Instance.SearchNearHuman(transform.position);
        }
    }
}
