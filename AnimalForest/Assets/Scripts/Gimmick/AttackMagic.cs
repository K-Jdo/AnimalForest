using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMagic : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;

    float defence;
    float damage;

    void Start()
    {
        cost = 30;
        power = 60;
    }

    private void OnTriggerEnter(Collider collider)
    {
        //衝突しているオブジェクトをリストに登録
        hit_objects.Add(collider.gameObject);

        foreach (GameObject i in hit_objects)
        {
            if (i.gameObject.CompareTag("Enemy"))
            {
                human = i.transform.GetComponent<Human>();
                human.SetDamage(power);
            }
        }
        //衝突する度にオブジェクトリストをリセットする
        hit_objects.Clear();
    }

}
