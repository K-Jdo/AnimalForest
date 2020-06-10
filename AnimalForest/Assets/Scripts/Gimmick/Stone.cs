using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private TryMove try_box;

    // Start is called before the first frame update
    void Start()
    {
        cost = 10;
        stantime = 1;
    }
    //ADD 範囲攻撃にする
    private void OnTriggerEnter(Collider collider)
    {
        //個数制限

        //衝突しているオブジェクトをリストに登録
        hit_objects.Add(collider.gameObject);

        foreach (GameObject i in hit_objects)
        {
            if (i.gameObject.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);

                try_box = i.GetComponent<TryMove>();
                try_box.enabled = false;

                Invoke("Release", stantime);
            }
            //StanEffect();
        }
        //衝突する度にオブジェクトリストをリセットする
        hit_objects.Clear();
    }

    void Release()
    {
        try_box.enabled = true;
    }
}
