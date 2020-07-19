using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox_test : MonoBehaviour
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
