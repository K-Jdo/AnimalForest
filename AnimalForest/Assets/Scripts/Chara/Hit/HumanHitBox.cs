// K.Joudo 2020
using UnityEngine;

// 人間用の範囲攻撃
public class HumanHitBox : HitBox
{
    Human human;
    Human.TargetType target_type;
    protected override void Awake()
    {
        human = transform.root.gameObject.GetComponent<Human>();
        target_type = Human.TargetType.notTarget;
    }

    private void Start()
    {
        power = human.GetStatus().power;
    }

    private void Update()
    {
        target_type = human.GetTarget();
    }

    protected override void OnTriggerExit(Collider other)
    {
        // ターゲットが人間かタワーかも判定する
        target_type = human.GetTarget();
        if (other.transform.tag.Contains("Animal")
            && target_type == Human.TargetType.animal)
        {
            CharacterDamage(other);
        }
        else if (other.transform.tag.Contains("Tower")
            && target_type == Human.TargetType.tower)
        {
            TowerDamage(other);
        }

    }

    void TowerDamage(Collider other)
    {
        Tower tower = other.GetComponent<Tower>();
        tower.TowerDamage(power);
    }
}
