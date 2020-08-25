// K.Joudo. 2020
using UnityEngine;
// カメラを回転させる
public class CameraRotate : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed);
    }
}
