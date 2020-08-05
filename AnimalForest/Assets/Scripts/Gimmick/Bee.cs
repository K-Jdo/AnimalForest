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

    int defence;
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
        if (flag == true)
        {
            timeElapsed += Time.deltaTime;

            for (int x = 0; x < 30; x++)
            {
                if (hit_objects == null || x > 30)
                {
                    flag = false;
                    x = 30;
                    Destroy(gameObject);
                }
                else if (timeElapsed >= 1.0f)
                {
                    defence = human.GetStatus().defence;
                    damage = power - defence;
                    human.SetDamage(damage, true);

                    //animator.SetBool("is_attack", true);


                    timeElapsed = 0f;
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
                    this.transform.parent = i.transform;
                    flag = true;
                }
            }
            hit_objects.Clear();
        }
    }
}
