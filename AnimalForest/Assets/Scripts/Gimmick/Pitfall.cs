//F.D.
//落とし穴の処理
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pitfall : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        cost = 40;
        gimmicktime = 3;
    }
    //ADD 範囲攻撃にする
    private void OnTriggerEnter(Collider collider)
    {
        //衝突しているオブジェクトをリストに登録
        hit_objects.Add(collider.gameObject);

        foreach (GameObject i in hit_objects)
        {
            if (i.gameObject.CompareTag("CharaEnemy"))
            {
                gameObject.SetActive(false);

                human = i.GetComponent<Human>();
                speed = human.GetStatus().speed;
                human.SetSpeed(0);

                Invoke("Release", gimmicktime);
            }
            //StanEffect();
        }
        //衝突する度にオブジェクトリストをリセットする
        hit_objects.Clear();
    }

    void Release()
    {
        human.SetSpeed(speed);
    }

    //void StanEffect()
    //{
    //    GameObject staneffect = Instantiate("エフェクト名") as GameObject;
    //    staneffect.transform.position = gameObject.transform.position;
    //}
}
