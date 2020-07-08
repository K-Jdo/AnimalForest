// K.Joudo. 2020

using UnityEngine;
// 人間に共通する動作をする抽象クラス

public abstract class Human : Character
{
    public enum TargetType { tower, animal, notTarget }

    protected TargetType target_type;

    protected override void Awake()
    {
        base.Awake();
        character_type = CharacterType.human;
        target_type = TargetType.tower;
    }

    private void Start()
    {
        // 最初のタワーの目標を決める
        target_object = TestManager.Instance.tower;
        agent.SetDestination(target_object.transform.position);
    }

    protected override void Update()
    {
        base.Update();
        ChangeTarget();
        //Debug.Log($"{status.name}のタイプ:{animation_type}");

        if (animation_type == AnimaionType.death)
        {
            // ここでコストを増やす処理をする
            //CostManager.Instance.cost += 50;
        }
    }

    protected override void ChangeTarget()
    {
        // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
        if (target_object == null)
        {
            animation_type = AnimaionType.walk;
            SetSpeed(status.speed);
            // ここで新しいタワーの目標を決める
            // とりあえず最初のタワーをいれておく
            target_object = TestManager.Instance.tower;
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
            else if(target_type == TargetType.tower)
            {
                // TODO タワーのダメージが出来たら作る
            }
            //if(target_character.status.hp <= 0)
            //{
            //    target_object = null;
            //}
            attack_time = 0.0f;
        }


        // これはTowerを参照するようになったら消す
        if (target_object.name == "wood1")
        {
            return;
        }

        base.Attack();
    }
}
