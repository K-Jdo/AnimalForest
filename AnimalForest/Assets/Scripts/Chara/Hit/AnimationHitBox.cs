// K.Joudo 2020
using UnityEngine;

// キリンのアニメーションで実行するプログラム
public class AnimationHitBox : MonoBehaviour
{
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
    }

    // Animationで実行するメソッド
    void ActivOnCollision()
    {
        boxCollider.enabled = true;
    }
    void NoCollide()
    {
        boxCollider.enabled = false;
    }
}
