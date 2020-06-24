// K.Joudo. 2020

using UnityEngine;
// 扇形のギズモを表示する範囲
// 参考:うら干物書き
//      [Unity]扇状のギズモを作ってみる
public class GizmoRange : MonoBehaviour
{
    // ギズモの範囲
    [SerializeField, Range(0.0f, 360.0f)]
    float width_angle = 0.0f;
    [SerializeField, Range(0.0f, 360.0f)]
    float height_angle = 0.0f;
    [SerializeField, Range(0.0f, 15.0f)]
    float length_angle = 0.0f;

    // 値を返すプロパティ
    public float WidthAngle { get { return width_angle; } }
    public float HeightAngle { get { return height_angle; } }
    public float Length { get { return length_angle; } }
}
