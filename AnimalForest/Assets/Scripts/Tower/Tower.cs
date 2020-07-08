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

    static GameObject[] towers;
    //static List<GameObject> towers = new List<GameObject>();
    public UnityEngine.UI.Slider slider;
    protected int hp;
    protected int max_hp;
    int damage;



    private void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");

        //transformを取得
        Transform transform = this.transform;

        Vector3 worldpos = transform.position;
        Vector3 localpos = transform.localPosition;
    }

    private void Update()
    {

        //HPバー模索中
        slider.maxValue = max_hp;
        slider.value = hp;
        Debug.Log($"{hp}");
    }
    //タワーダメージ計算
    public void TowerDamage()
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
    }
}
