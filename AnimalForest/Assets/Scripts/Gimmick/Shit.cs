//F.D.
//ギミック：うんちの処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;
    protected Animation anim;

    int defence;
    int damage;

    void Start()
    {
        cost = 30;
        power = 10;
        anim = gameObject.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        //衝突しているオブジェクトをリストに登録
        hit_objects.Add(collider.gameObject);

        foreach (GameObject i in hit_objects)
        {
            if (i.gameObject.CompareTag("CharaEnemy"))
            {
                human = i.transform.GetComponent<Human>();
                defence = human.GetStatus().defence;
                damage = power - defence;
                human.SetDamage(damage, true);

                Destroy(gameObject);
            }
        }
        //衝突する度にオブジェクトリストをリセットする
        hit_objects.Clear();
    }
}
