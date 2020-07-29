// K.Joudo. 2020

using UnityEngine;

// 車を出現させるクラス
public class CarSpawn : MonoBehaviour
{
    [SerializeField] int spawn_count;
    [SerializeField] GameObject car = default;
    [SerializeField] float y_rotate;
    private void Update()
    {
        if(spawn_count <= HumanManager.Instance.kill_count)
        {
            Instantiate(car, transform.position, new Quaternion(0, y_rotate, 0, 0));
            Destroy(gameObject);
        }
    }
}
