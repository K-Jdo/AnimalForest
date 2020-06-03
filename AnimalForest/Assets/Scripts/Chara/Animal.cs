// K.Joudo. 2020
using UnityEngine;

// 動物に共通する動作を制御するクラス
public class Animal : Character
{
    protected override void Start()
    {
        base.Start();
        character_type = CharacterType.animal;
        target_object = HumanManager.Instance.SearchNearHuman(transform.position);
        target_character = target_object.GetComponent<Character>();
        agent.SetDestination(target_object.transform.position);
    }

    protected override void Update()
    {
        base.Update();
        ChangeTarget();
        if(animation_type == AnimaionType.attack)
        {
            Debug.Log($"{status.name}が攻撃している");
        }
    }

    protected override void ChangeTarget()
    {
        //throw new System.NotImplementedException();

        if(target_object == null)
        {
            // 敵を撃破すると次の敵を探す
            animation_type = AnimaionType.walk;
            target_object = HumanManager.Instance.SearchNearHuman(transform.position);
            target_character = target_object.GetComponent<Character>();
        }
    }
}
