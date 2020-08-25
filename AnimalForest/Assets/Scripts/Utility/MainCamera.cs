// K.Joudo. 2020
using System.Collections.Generic;
using UnityEngine;

// カメラの向きを変更するクラス
public class MainCamera : MonoBehaviour
{
    // 変更後の座標と角度を取っておく
    List<Vector3> positions = new List<Vector3>();
    List<Vector3> angles = new List<Vector3>();
    // 次に切り替えるカメラの番号
    int next_camera_num;
    private void Awake()
    {
        // カメラ切り替え後の座標を格納
        // 1カメ
        positions.Add(transform.position);
        angles.Add(new Vector3(20, 180, 0));

        // 2カメ
        positions.Add(new Vector3(-14, 7, 0));
        angles.Add(new Vector3(20, 90, 0));

        // 3カメ
        positions.Add(new Vector3(14, 7, 0));
        angles.Add(new Vector3(20, 270, 0));

        next_camera_num = 1;
    }

    private void Update()
    {
        // 右クリックでカメラ切り替え
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = positions[next_camera_num];
            transform.rotation = Quaternion.Euler(angles[next_camera_num]);
            next_camera_num++;
            if (next_camera_num >= 3)
            {
                next_camera_num = 0;
            }
        }
    }
}
