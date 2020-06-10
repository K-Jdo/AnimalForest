// K.Joudo 2020
using UnityEngine;

// 敵を出現させるクラス
public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject human = default;
    float count = 0;

    void Update()
    {
        if (!HumanManager.Instance.Is_spawn)
        {
            // 数が上限に達すると何もしない
            return;
        }

        // 2秒毎にスポーン
        count += Time.deltaTime;
        if(count >= 2.0f)
        {
            HumanManager.Instance.SetHuman(Instantiate(human, transform.transform));
            count = 0;
        }
    }
}
