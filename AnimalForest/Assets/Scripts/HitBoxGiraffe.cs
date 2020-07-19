using UnityEngine;

public class HitBoxGiraffe : MonoBehaviour
{
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
    }

    void ActivOnCollision()
    {
        boxCollider.enabled = true;
    }
    void NoCollide()
    {
        boxCollider.enabled = false;
    }
}
