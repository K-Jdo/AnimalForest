// S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// コストの管理
public class CostManager : MonoBehaviour
{
    //初めから持っているコスト
    public int cost;
    //時間によってプラスするコスト
    public int cost_plus;
    //コストをプラスする時間
    public float time_out;
    //時間計測する変数
    private float cost_time;
    //コストを表示
    public Text cost_text;
    // Update is called once per frame
    void Update()
    {
        //何秒経ったか計測する
        cost_time += Time.deltaTime;
        //計測している時間がコストをプラスする時間になったら

        if (cost_time >= time_out)
        {
            //コストをプラスできるか確認
            Debug.Log("Cost:"+(cost += cost_plus));
            //計測時間を0に戻す
            cost_time = 0.0f;
        }
        cost_text.text = cost.ToString();
    }
}
