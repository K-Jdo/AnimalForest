// K.Joudo. 2020

using UnityEngine;

// ボスの処理をするクラス
public class BossHuman : Human
{
    RangeAttaker my_range_attack;
    protected override void Awake()
    {
        status = new Status(2000, 45, 10, 0.5f, 0, "BOSS");
        base.Awake();
        my_range_attack = GetComponent<RangeAttaker>();
        my_range_attack.my_type = character_type;
        //range = my_range_attack.SearchRadius;
    }

    protected override void ChangeTarget()
    {
        // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
        if (my_range_attack.characters.Count <= 0)
        {
            animation_type = AnimaionType.walk;
            SetSpeed(status.speed);
            // ここで新しいタワーの目標を決める
            target_object = TowerManager.Instance.SearchTowerObject(transform.position);
            // とりあえず最初のタワーをいれておく
            //target_object = TestManager.Instance.tower;
            target_tower = target_object.GetComponent<Tower>();
            target_type = TargetType.tower;
        }
        else if (animation_type == AnimaionType.damage)
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
    /// 範囲攻撃に上書き
    /// </summary>
    protected override void Attack()
    {
        attack_time += Time.deltaTime;
        // 攻撃のアニメーションが終わると攻撃が完了
        // アニメーションが出来たらこの条件に変えておく
        //if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
        //    anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        if (attack_time >= 1.5f)
        {
            if (target_type == TargetType.animal)
            {
                // 範囲内にいる敵を攻撃
                // 処理中に母数が変わる可能性があるのでforeachは使えない
                var range_character = my_range_attack.characters;
                for (int i = 0; i < range_character.Count; i++)
                {
                    if (range_character[i] == null)
                    {
                        my_range_attack.characters.Remove(range_character[i]);
                        continue;
                    }
                    // 自分と同じタイプだと味方なので攻撃しない
                    if (range_character[i].character_type == character_type)
                    {
                        continue;
                    }
                    // ダメージ計算
                    int damage = status.power - range_character[i].GetStatus().defence;
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
                    range_character[i].SetDamage(damage);
                }
            }
            else if (target_type == TargetType.tower)
            {
                // TODO タワーのダメージが出来たら作る
            }

            attack_time = 0.0f;
        }
    }

}
