// K.Joudo. 2020
using UnityEngine;

// ステージを回転させるクラス
public class StsgeRotate : MonoBehaviour
{
    [SerializeField] float y = 0.05f;
    void Update()
    {
        transform.Rotate(0.0f, y, 0.0f);
    }
}
