//F.D.
//ギミック：蜂の処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;
    private Drag drag;
    //protected Animator animator;

    private float timeElapsed;

    bool triggerflag = true;
    bool flag = false;

    int count;
    int damage;

    void Start()
    {
        cost = 1000;
        power = 10;
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //ADD オブジェクトを透過？追尾？をさせる
        //ADD 一体当たったら次に通ったキャラには反応しないようにする
        if (flag)
        {
            timeElapsed += Time.deltaTime;

            if (hit_objects == null)
            {
                Destroy(gameObject);
            }
            if (timeElapsed >= 1.0f)
            {
                human.SetDamage(damage, true);
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

    //
    private void TrapJudgment()
    {

    }


    private void OnTriggerStay(Collider collider)
    {
        if (triggerflag)
        {
            triggerflag = false;
            //衝突しているオブジェクトをリストに登録
            hit_objects.Add(collider.gameObject);
            foreach (GameObject i in hit_objects)
            {
                if (i.gameObject.CompareTag("CharaEnemy"))
                {
                    human = i.transform.GetComponent<Human>();
                    int defence = human.GetStatus().defence;
                    damage = power - defence;
                    this.transform.parent = i.transform;
                    flag = true;
                }
            }
            hit_objects.Clear();
        }
    }
}
