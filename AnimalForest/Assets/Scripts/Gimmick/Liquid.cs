//F.D.
//ギミック：謎の液体X
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : GimmickManager
{
    private List<GameObject> hit_objects = new List<GameObject>();
    private Animal animal;

    private float timeElapsed;

    bool flag = false;

    int atk;


    private void Start()
    {
        cost = 500;
    }

    private void Update()
    {
        if(flag == true)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed <= 10.0f)
            {
                atk = animal.GetStatus().power;
                atk += 10;
                //実装
                //ADD SetPowerの追加;
            }
            else if(timeElapsed > 10.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        hit_objects.Add(collider.gameObject);

        foreach(GameObject i in hit_objects)
        {
            if (i.gameObject.CompareTag("CharaAnimal"))
            {
                animal = i.transform.GetComponent<Animal>();
                flag = true;                
            }
        }
        hit_objects.Clear();
    }
}
