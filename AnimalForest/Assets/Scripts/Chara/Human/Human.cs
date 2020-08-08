// K.Joudo. 2020

using UnityEngine;
// 人間に共通する動作をする抽象クラス
public abstract class Human : Character
{
    public enum TargetType { tower, animal, notTarget }

    protected TargetType target_type;
    protected Tower target_tower;
    protected override void Awake()
    {
        base.Awake();
        character_type = CharacterType.human;
        target_type = TargetType.tower;
    }

    protected virtual void Start()
    {
        // 最初のタワーの目標を決める
        target_object = TowerManager.Instance.SearchTowerObject(transform.position);
        target_tower = target_object.GetComponent<Tower>();
        agent.SetDestination(target_object.transform.position);
    }

    protected override void Update()
    {
        base.Update();
        ChangeTarget();
    }

    protected override void ChangeTarget()
    {
        // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
        if (target_object == null)
        {
            animation_type = AnimaionType.walk;
            anim.SetBool("isIdol", false);
            SetSpeed(status.speed);
            // ここで新しいタワーの目標を決める
            target_object = TowerManager.Instance.SearchTowerObject(transform.position);
            if(target_object == null)
            {
                // 見つからなければ何もしない
                return;
            }
            target_tower = target_object.GetComponent<Tower>();
            target_type = TargetType.tower;
        }
        else if (animation_type == AnimaionType.damage)
        {
            // ダメージを受けたらターゲットを動物に変更
            animation_type = AnimaionType.attack;
            SetSpeed(0);
            target_object = AnimalManager.Instance.SearchNearObject(transform.position);
            // 攻撃時にターゲットの方向を向く
            transform.LookAt(target_object.transform);
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
                target_tower.TowerDamage(status.power);
            }
            attack_time = 0.0f;
        }
    }

    protected override void Deth()
    {
        animation_type = AnimaionType.death;
        SetSpeed(0);
        HumanManager.Instance.kill_count++;
        CostManager.Instance.cost += status.cost;
        Destroy(gameObject);

    }

    public TargetType GetTarget() { return target_type; }
}
