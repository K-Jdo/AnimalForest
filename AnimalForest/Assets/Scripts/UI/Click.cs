// S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    //複製したいものを入れる
    public GameObject obj;
    //クリックされたオブジェクトを入れる
    GameObject clicked_object;
    //ボタンを押した
    private bool trigger = false;
    //使うコスト
    public int use_cost;
    //テキストを表示
    public Text use_cost_text;

    private void Start()
    {
        //ボタンにテキスト表示
        use_cost_text.text = use_cost.ToString() + "P";
    }
    //ボタンを押したときの処理
    public void OnClick()
    {
        trigger = true;
    }
    void Update()
    {
        if (trigger == true)
        {
            if (Input.GetMouseButton(0))
            {
                OnClicked();
            }
        }
    }
    public void OnClicked()
    {
        //スクリーンから見たマウスの座標を得る
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //クリックされた座標を格納する
        RaycastHit hit;

        //rayが当たっていたら
        if (Physics.Raycast(ray, out hit))
        {
            //クリックされた座標
            Vector3 pos = hit.point;
            //クリックされたゲームオブジェクト
            clicked_object = hit.collider.gameObject;
            //クリックされたものが指定されたレイヤーなら
            if (clicked_object.layer == 8)
            {
                if (CostManager.Instance.cost >= use_cost)
                {
                    //オブジェクトを複製
                    Instantiate(obj, pos, Quaternion.identity);
                    CostManager.Instance.cost -= use_cost;
                }
            }
        }
        trigger = false;
    }
}
