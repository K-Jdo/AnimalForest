// K.Joudo. 2020

// 動物に共通する動作をする抽象クラス
public abstract class Animal : Character
{
    protected override void Awake()
    {
        base.Awake();
        character_type = CharacterType.animal;
    }

    private void Start()
    {
        // 最初のターゲットを探す
        target_object = HumanManager.Instance.SearchNearObject(transform.position);
        if (target_object != null)
        {
            target_character = target_object.GetComponent<Character>();
            agent.SetDestination(target_object.transform.position);
        }
    }

    protected override void Update()
    {
        ChangeTarget();
        base.Update();
    }

    protected override void ChangeTarget()
    {
        if (target_object == null)
        {
            // 敵を撃破すると次の敵を探す
            animation_type = AnimaionType.walk;
            anim.SetBool("isIdol", false);
            target_object = HumanManager.Instance.SearchNearObject(transform.position);
            if (target_object != null)
            {
                target_character = target_object.GetComponent<Character>();
            }
        }
    }

    /// <summary>
    /// 液体Xの効果でパワーの変更
    /// </summary>
    public void SetPower(int power)
    {
        status.power = power;
    }
}
