// K.Joudo. 2020

using UnityEngine;


public class Giraffe : Animal
{
    RangeAttaker my_range_attak;

    protected override void Awake()
    {
        status = new Status(150, 25, 10, 1.5f, 1000, "キリン");
        base.Awake();
        my_range_attak = GetComponent<RangeAttaker>();
        range = my_range_attak.SearchRadius;
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
            // 範囲内にいる敵を攻撃
            foreach (var target in my_range_attak.characters)
            {
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
        }

    }
}
