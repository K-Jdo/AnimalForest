// K.Joudo. 2020

using UnityEngine;

// シマウマの処理をするクラス
// 範囲攻撃の実装対象
public class Giraffe : Animal
{
    //RangeAttaker my_range_attack;
    [SerializeField] GameObject test_obj = default;

    protected override void Awake()
    {
        status = new Status(150, 25, 10, 1.5f, 1000, "キリン");
        base.Awake();
        //my_range_attack = test_obj.GetComponent<RangeAttaker>();
        //my_range_attack.my_type = character_type;
        //range = my_range_attack.SearchRadius;
        range = 1;
    }

    /// <summary>
    /// 範囲攻撃に上書き
    /// </summary>
    protected override void Attack()
    {
        /*
        attack_time += Time.deltaTime;
        // 攻撃のアニメーションが終わると攻撃が完了
        // アニメーションが出来たらこの条件に変えておく
        //if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
        //    anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        if (attack_time >= 1.5f)
        {
            // 範囲内にいる敵を攻撃
            // 処理中に母数が変わる可能性があるためエラーがでる
            foreach (var target in my_range_attack.characters)
            {
                if (target == null)
                {
                    my_range_attack.characters.Remove(target);
                }
                // 自分と同じタイプだと味方なので攻撃しない
                if (target.character_type == character_type)
                {
                    continue;
                }

                int damage = status.power - target.GetStatus().defence;
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
                target.SetDamage(damage);
            }
            //if(target_character.status.hp <= 0)
            //{
            //    target_object = null;
            //}
            attack_time = 0.0f;
        }*/

    }
}
