// K.Joudo. 2020

// 人間に共通する動作を制御するクラス
public class Human : Character
{
    protected override void Start()
    {
        base.Start();
        // 最初のタワーの目標を決める
    }

    protected override void Update()
    {
        base.Update();
        if(type == AnimaionType.death)
        {
            // ここでコストを増やす処理をする
            // Costmanager.Instance.cost += status.cost;
        }
    }

    protected override void ChangeTarget()
    {
        //throw new System.NotImplementedException();
        
        // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
        if(target == null)
        {
            type = AnimaionType.walk;
            // ここに新しいタワーの目標を決める
        }
        else if(type == AnimaionType.damage)
        {
            type = AnimaionType.attack;
            target = AnimalManager.Instance.SearchNearAnimal(transform.position);
        }
    }
}
