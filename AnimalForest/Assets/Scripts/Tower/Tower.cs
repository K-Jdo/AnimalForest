//F.D.
//タワークラス
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA;
using Vector3 = UnityEngine.Vector3;

public class Tower : MonoBehaviour
{
    private Human human;

    GameObject[] towers;
    public UnityEngine.UI.Slider slider;
    protected int hp;
    protected int max_hp;
    int damage;



    private void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
    }

    private void Update()
    {

        //HPバー模索中
        slider.maxValue = max_hp;
        slider.value = hp;
        Debug.Log($"{towers}");

        //Debug.Log($"{hp}");
    }
    //タワーダメージ計算
    //まだ上手くいっていない為、現在はコメント
    /*    public void TowerDamage()
        {
            human = GetComponent<Human>();
            damage = human.GetStatus().power;
            hp -= damage;
            //HPが0になると破壊。
            //ADD エフェクト処理追加する
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }*/

    //タワーの座標を返す処理
    public Vector3 TowerPosition()
    {
        //transformを取得
        Transform transform = this.transform;

        Vector3 worldpos = transform.position;
        //Vector3 localpos = transform.localPosition;

        return worldpos;
    }
}
