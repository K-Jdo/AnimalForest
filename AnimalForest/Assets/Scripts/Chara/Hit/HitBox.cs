// K.Joudo 2020
using UnityEngine;

// 範囲攻撃の当たり判定
public class HitBox : MonoBehaviour
{
    protected int power;
    protected virtual void Awake()
    {
        GameObject obj = transform.root.gameObject;
        Character parent = obj.GetComponent<Character>();
        power = parent.GetStatus().power;
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Contains("Enemy"))
        {
            CharacterDamage(other);
        }
    }

    protected void CharacterDamage(Collider other)
    {
        Character character = other.GetComponent<Character>();
        int damage = power - character.GetStatus().defence;
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
        character.SetDamage(damage);
    }
}
