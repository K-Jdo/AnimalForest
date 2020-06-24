﻿// K.Joudo 2020
using UnityEngine;

// 敵を出現させるクラス
public class HumanSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject human = default;
    [SerializeField] float spwan_time = 3.0f; // デフォルトは3秒おきに出現

    [SerializeField] private GameObject[] humans = default;
    // 各敵の出現率
    [SerializeField] int small_spwan_rate = 0;
    [SerializeField] int middle_spwan_rate = 0;
    //[SerializeField] int big_spwan_rate = 0;
    //[SerializeField] int rare_spwan_rate = 0;

    const int MAX_RATE = 99;
    float timer_count = 0;

    void Update()
    {
        if (!HumanManager.Instance.Is_spawn)
        {
            // 数が上限に達すると何もしない
            return;
        }

        // spwan_timeを基準にスポーン
        timer_count += Time.deltaTime;
        if(timer_count >= spwan_time)
        {
            // ランダムで出現させる敵を決定
            int ram = Random.Range(0, MAX_RATE);
            int middle = small_spwan_rate + middle_spwan_rate;
            //int big = middle + big_spwan_rate;
            //int rare = big + rare_spwan_rate;
            if (ram >= 0 && ram < 60)
            {
                HumanManager.Instance.SetHuman(Instantiate(humans[0], transform.transform));
            }
            else if (ram >= small_spwan_rate && ram < middle)
            {
                HumanManager.Instance.SetHuman(Instantiate(humans[1], transform.transform));
            }
            else if (ram >= middle /*&& rare_spwan_rate < big*/)
            {
                HumanManager.Instance.SetHuman(Instantiate(humans[2], transform.transform));
            }
            //else if(ram >= big && ram < rare)
            //{
            //    HumanManager.Instance.SetHuman(Instantiate(human[3], transform.transform));
            //}


            //HumanManager.Instance.SetHuman(Instantiate(human, transform.transform));
            timer_count = 0;
        }
    }
}
