// K.Joudo. 2020

// 人間に共通する動作をする抽象クラス

public abstract class Human : Character
{
    protected override void Awake()
    {
        base.Awake();
        character_type = CharacterType.human;
    }

    void Start()
    {
        // 最初のタワーの目標を決める
        target_object = TestManager.Instance.tower;
        agent.SetDestination(target_object.transform.position);
    }

    protected override void Update()
    {
        base.Update();
        ChangeTarget();
        if(animation_type == AnimaionType.death)
        {
            // ここでコストを増やす処理をする
            //CostManager.Instance.cost += 50;
        }
    }

    protected override void ChangeTarget()
    {
        // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
        if(target_object == null)
        {
            animation_type = AnimaionType.walk;
            // ここで新しいタワーの目標を決める
            // とりあえず最初のタワーをいれておく
            target_object = TestManager.Instance.tower;
        }
        else if(animation_type == AnimaionType.damage)
        {
            animation_type = AnimaionType.attack;
            target_object = AnimalManager.Instance.SearchNearAnimal(transform.position);
            if (target_object != null)
            {
                target_character = target_object.GetComponent<Character>();
            }
        }
    }

    protected override void Attack()
    {
        // これはTowerを参照するようになったら消す
        if(target_object.name == "wood1")
        {
            return;
        }

        base.Attack();
    }
}
