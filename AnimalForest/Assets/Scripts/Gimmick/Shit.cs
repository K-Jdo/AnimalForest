//F.D.
//ギミック：うんちの処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;
    protected Animator anim;

    void Start()
    {
        cost = 30;
        power = 10;
        human = transform.parent.GetComponent<Human>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("poop_attack") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            human.SetDamage(power, true);
            Destroy(gameObject);
        }
    }
}
