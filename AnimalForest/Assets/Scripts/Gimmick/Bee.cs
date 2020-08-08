//F.D.
//ギミック：蜂の処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;
    //protected Animator animator;

    private float timeElapsed;

    int count;

    void Start()
    {
        cost = 1000;
        power = 10;
        //animator = GetComponent<Animator>();
        human = transform.parent.GetComponent<Human>();
    }

    private void Update()
    {
        //ADD オブジェクトを透過？追尾？をさせる
        //ADD 一体当たったら次に通ったキャラには反応しないようにする
        timeElapsed += Time.deltaTime;

        if (hit_objects == null)
        {
            Destroy(gameObject);
        }
        if (timeElapsed >= 1.0f)
        {
            human.SetDamage(power, true);
            count++;
            //animator.SetBool("is_attack", true);
            timeElapsed = 0f;
            if (count > 30)
            {
                Destroy(gameObject);
            }
        }
    }
}
