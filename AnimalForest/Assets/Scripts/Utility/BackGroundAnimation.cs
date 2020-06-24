using System.Collections;
using UnityEngine;

public class BackGroundAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;

    Renderer render;

    void Awake()
    {
        render = GetComponent<Renderer>();
    }


    void Update()
    {
        float scroll = Mathf.Repeat(Time.time * speed, 1);
        Vector2 offset = new Vector2(scroll, 0);
        render.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}