// K.Joudo. 2020
using UnityEngine;

// 人間に共通する動作を制御するクラス
public class Human : Character
{    
    protected override void Start()
    {
        base.Start();
        character_type = CharacterType.human;
        // 最初のタワーの目標を決める
        target_object = TestManager.Instance.tower;
        agent.SetDestination(target_object.transform.position);
    }

    protected override void Update()
    {
        base.Update();
        ChangeTarget();
        if(animation_type == AnimaionType.death)
        {
            // ここでコストを増やす処理をする
            // Costmanager.Instance.cost += status.cost;
        }
    }

    protected override void ChangeTarget()
    {
        //throw new System.NotImplementedException();
        
        // ターゲットを撃破する、もしくは攻撃を受けると標的を変更
        if(target_object == null)
        {
            animation_type = AnimaionType.walk;
            // ここに新しいタワーの目標を決める
        }
        else if(animation_type == AnimaionType.damage)
        {
            animation_type = AnimaionType.attack;
            target_object = AnimalManager.Instance.SearchNearAnimal(transform.position);
            target_character = target_object.GetComponent<Character>();
        }
    }

    protected override void Attack()
    {
        // これはTowerを参照するようになったら消す
        if(target_object.name == "wood1")
        {
            Debug.Log("木を狙っている");
            return;
        }

        base.Attack();
        Debug.Log("クマを狙っている");

    }
}
