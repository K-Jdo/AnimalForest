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
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void Deth()
    {
        animation_type = AnimaionType.death;
        SetSpeed(0);
        HumanManager.Instance.kill_count++;
        CostManager.Instance.cost += status.cost;
        // ボスの撃破フラグを立てる
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
