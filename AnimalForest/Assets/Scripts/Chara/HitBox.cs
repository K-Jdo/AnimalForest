// K.Joudo 2020
using UnityEngine;

// キリンの攻撃当たり判定
public class Hitbox : MonoBehaviour
{
    int power;

    private void Start()
    {
        GameObject obj = transform.root.gameObject;
        power = obj.GetComponent<Character>().GetStatus().power;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Contains("Enemy"))
        {
            Debug.Log("当たったよ!");
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
}
