// K.Joudo. 2020

// 動物に共通する動作をする抽象クラス
public abstract class Animal : Character
{
    protected override void Awake()
    {
        base.Awake();
        character_type = CharacterType.animal;
    }

    void Start()
    {
        target_object = HumanManager.Instance.SearchNearHuman(transform.position);
        if (target_object != null)
        {
            target_character = target_object.GetComponent<Character>();
            agent.SetDestination(target_object.transform.position);
        }
    }

    protected override void Update()
    {
        ChangeTarget();
        // 見つからなかったら何もしない
        if (target_object == null)
        {
            return;
        }
        base.Update();
        //if(animation_type == AnimaionType.attack)
        //{
        //    Debug.Log($"{status.name}が攻撃している");
        //}
    }

    protected override void ChangeTarget()
    {
        if (target_object == null)
        {
            // 敵を撃破すると次の敵を探す
            animation_type = AnimaionType.walk;
            target_object = HumanManager.Instance.SearchNearHuman(transform.position);
            if (target_object != null)
            {
                target_character = target_object.GetComponent<Character>();
            }
        }
    }
}
