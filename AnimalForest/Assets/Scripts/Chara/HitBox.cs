using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Contains("Enemy"))
        {
            Debug.Log("当たったよ!");
            other.GetComponent<Human>().SetDamage(50);
        }
    }
}
