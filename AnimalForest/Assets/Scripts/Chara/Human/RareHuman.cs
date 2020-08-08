// K.Joudo 2020

using UnityEngine;
// レア人間のクラス
public class RareHuman : Human
{
    protected override void Awake()
    {
        status = new Status(15, 500, 15, 3.0f, 10000, "レア人間");
        base.Awake();
    }

    protected override void Start()
    {
        // 最初のターゲット(動物)を決める
        target_object = AnimalManager.Instance.SearchNearObject(transform.position);
        target_character = target_object.GetComponent<Character>();
        agent.SetDestination(target_object.transform.position);
    }

    /// <summary>
    /// レア人間は動物のみ攻撃する
    /// </summary>
    protected override void ChangeTarget()
    {
        // ターゲットを撃破すると標的を変更
        if (target_object == null)
        {
            animation_type = AnimaionType.attack;
            SetSpeed(0);
            target_object = AnimalManager.Instance.SearchNearObject(transform.position);
            if (target_object != null)
            {
                target_character = target_object.GetComponent<Character>();
                target_type = TargetType.animal;
            }
        }
    }

    /// <summary>
    /// タワーに攻撃する部分を削除
    /// </summary>
    protected override void Attack()
    {
        attack_time += Time.deltaTime;

        if (attack_time >= 1.5f)
        {
            if (target_type == TargetType.animal)
            {
                int damage = status.power - target_character.GetStatus().defence;
                if (damage <= 0)
                {
                    damage = 1;
                }
                else
                {
                    // 乱数によって振れ幅を付ける(-5, 5)
                    int r = Random.Range(-5, 6);
                    damage += r;
                }
                target_character.SetDamage(damage);
            }
            attack_time = 0.0f;
        }

    }
}
