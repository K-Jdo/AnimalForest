﻿// K.Joudo 2020

using System.Collections.Generic;
using UnityEngine;
using MyScript;
// 範囲攻撃のテスト
// TODO 使い終わったら消す
public class RangeAttaker : MonoBehaviour
{
    [SerializeField] Material test_material = default;
    Material default_material;
    Renderer my_renderer;

    [SerializeField, Range(0.0f, 360.0f)]
    float search_angle = 0.0f;
    public float SearchAngle { get { return search_angle; } }

    public float SearchRadius { get; private set; } = 2.5f;
    SphereCollider sphere_collider;

    List<GameObject> target_list = new List<GameObject>();
    List<FoundObject> found_list = new List<FoundObject>();
    float search_cos_theta = 0.0f;

    public List<Character> characters = new List<Character>();

    private void Awake()
    {
        my_renderer = GetComponent<Renderer>();
        default_material = my_renderer.material;
        sphere_collider = GetComponent<SphereCollider>();
        ApplySearchAngle();
    }

    private void Update()
    {
        if(target_list.Count >= 1)
        {
            Debug.Log(1);
        }
        UpdateFoundObject();
        SearchRadius = sphere_collider.radius;
        Debug.Log($"target:{target_list.Count}");
        Debug.Log($"found:{found_list.Count}");
    }

    private void UpdateFoundObject()
    {
        foreach (var found_data in found_list)
        {
            GameObject target = found_data.Obj;
            if (target == null)
            {
                continue;
            }

            bool is_found = CheckFoundObject(target);
            found_data.Update(is_found);

            if (found_data.IsFound())
            {
                OnFound(target);
            }
            else if (found_data.IsLost())
            {
                OnLost(target);
            }
        }
    }

    private bool CheckFoundObject(GameObject target)
    {
        // yを0にしてxとzだけが欲しい
        Vector3 my_positionXZ = Vector3.Scale(transform.position, new Vector3(1.0f, 0.0f, 1.0f));
        Vector3 target_positionXZ = Vector3.Scale(target.transform.position, new Vector3(1.0f, 0.0f, 1.0f));

        // 正規化
        Vector3 to_target_dir = (target_positionXZ - my_positionXZ).normalized;
        if(!IsRangeAngle(to_target_dir, transform.forward, search_cos_theta))
        {
            return false;
        }

        return true;
    }

    private bool IsRangeAngle(Vector3 forward, Vector3 to_target_dir, float cos_theta)
    {
        // 方向ベクトルがない場合は、同位置にいるものだとする
        // ベクトルの2乗の長さと最小値を比較
        if(to_target_dir.sqrMagnitude <= Mathf.Epsilon)
        {
            return false;
        }
        
        // ベクトルの内積
        float dot = Vector3.Dot(forward, to_target_dir);
        return dot >= cos_theta;
    }

    private void OnFound(GameObject found_object)
    {
        target_list.Add(found_object);
        characters.Add(found_object.GetComponent<Character>());
        my_renderer.material = test_material;
    }

    private void OnLost(GameObject lost_object)
    {
        target_list.Remove(lost_object);
        characters.Remove(lost_object.GetComponent<Character>());
        my_renderer.material = default_material;
    }

    private void ApplySearchAngle()
    {
        float rad = search_angle * 0.5f * Mathf.Deg2Rad;
        search_cos_theta = Mathf.Cos(rad);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"トリガー発動:{other.name}");
        // キャラクター以外は無視する
        if (!other.tag.Contains("Chara"))
        {
            return;
        }

        GameObject enter_object = other.gameObject;
        // 多重登録が出来ないようにする
        // リストから同じのがないか探している
        if (found_list.Find(value => value.Obj == enter_object) == null)
        {
            found_list.Add(new FoundObject(enter_object));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"トリガー終了:{other.name}");
        GameObject exit_object = other.gameObject;
        var found_date = found_list.Find(value => value.Obj == exit_object);
        if (found_date == null)
        {
            return;
        }

        if (found_date.IsCurrentFound())
        {
            OnLost(found_date.Obj);
        }

        found_list.Remove(found_date);
    }

    /// <summary>
    /// シリアライズの値が変更されると呼び出される
    /// </summary>
    private void OnValidate()
    {
        ApplySearchAngle();
    }

}
