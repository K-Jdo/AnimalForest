//F.D.
//ギミック：石の処理
//ADD　humanとの兼ね合いを修正
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Human human;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        cost = 10;
        gimmicktime = 1;
    }
    //ADD 範囲攻撃にする
    private void OnTriggerEnter(Collider collider)
    {
        //個数制限

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
