// K.Joudo. 2020

using UnityEngine;

// 範囲攻撃の当たり判定を分けるためのクラス
public class RangeCollide : MonoBehaviour
{
    [SerializeField] GameObject obj = default;
    Character character;
    private void Start()
    {
        character = obj.GetComponent<Character>();
    }

    private void Update()
    {
        if (character.animation_type != Character.AnimaionType.attack)
        {
            transform.position = obj.transform.transform.position;
            transform.rotation = obj.transform.rotation;
        }
    }
}
