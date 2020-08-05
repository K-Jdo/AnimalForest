// K.Joudo. 2020

using UnityEngine;

// ボスの処理をするクラス
public class BossHuman : Human
{
    //RangeAttaker my_range_attack;
    protected override void Awake()
    {
        status = new Status(2000, 45, 10, 0.5f, 0, "BOSS");
        base.Awake();
        //my_range_attack = GetComponent<RangeAttaker>();
        //my_range_attack.my_type = character_type;
        //range = my_range_attack.SearchRadius;
    }

    //protected override void ChangeTarget()
    //{
    //    // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
    //    if (/*my_range_attack.characters.Count <= 0 || */target_object == null)
    //    {
    //        animation_type = AnimaionType.walk;
    //        anim.SetBool("isIdol", false);
    //        SetSpeed(status.speed);
    //        // ここで新しいタワーの目標を決める
    //        target_object = TowerManager.Instance.SearchTowerObject(transform.position);
    //        // とりあえず最初のタワーをいれておく
    //        //target_object = TestManager.Instance.tower;
    //        target_tower = target_object.GetComponent<Tower>();
    //        target_type = TargetType.tower;
    //    }
    //    else if (animation_type == AnimaionType.damage)
    //    {
    //        animation_type = AnimaionType.attack;
    //        SetSpeed(0);
    //        target_object = AnimalManager.Instance.SearchNearObject(transform.position);
    //        if (target_object != null)
    //        {
    //            target_character = target_object.GetComponent<Character>();
    //            target_type = TargetType.animal;
    //        }
    //    }

    //}

    protected override void Deth()
    {
        animation_type = AnimaionType.death;
        // TODO ここで死亡アニメーションを再生
        SetSpeed(0);
        HumanManager.Instance.kill_count++;
        CostManager.Instance.cost += status.cost;
        GameManager.Instance.Is_boss_defeat = true;
        Destroy(gameObject);
    }


    /// <summary>
    /// 範囲攻撃に上書き
    /// </summary>
    protected override void Attack()
    {
        // 攻撃方法は別に持っているので何もしない
    }
}
