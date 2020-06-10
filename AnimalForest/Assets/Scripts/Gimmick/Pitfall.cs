﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;

    // Start is called before the first frame update
    void Start()
    {
        cost = 40;
        stantime = 3;
    }
    //ADD 範囲攻撃にする
    private void OnTriggerEnter(Collider collider)
    {
        //衝突しているオブジェクトをリストに登録
        hit_objects.Add(collider.gameObject);

        foreach (GameObject i in hit_objects)
        {
            if (i.gameObject.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);

                human = i.GetComponent<Human>();
                human.enabled = false;

                Invoke("Release", stantime);
            }
            //StanEffect();
        }
        //衝突する度にオブジェクトリストをリセットする
        hit_objects.Clear();
    }

    void Release()
    {
        human.enabled = true;
    }

    //void StanEffect()
    //{
    //    GameObject staneffect = Instantiate("エフェクト名") as GameObject;
    //    staneffect.transform.position = gameObject.transform.position;
    //}
}