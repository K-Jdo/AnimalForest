// K.Joudo. 2020
using UnityEngine;

// 車を出現させるクラス
public class CarSpawn : MonoBehaviour
{
    [SerializeField] int spawn_count = 5;
    [SerializeField] GameObject car = default;
    [SerializeField] float y_rotate = 180;
    private void Update()
    {
        // 一定数人間が倒されると車(スポナー)を出現させる
        if(spawn_count <= HumanManager.Instance.kill_count)
        {
            Instantiate(car, transform.position, new Quaternion(0, y_rotate, 0, 0));
            Destroy(gameObject);
        }
    }
}
