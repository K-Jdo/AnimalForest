//F.D.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : SingletonMonoBehaviour<TowerManager>
{
    [SerializeField] List<GameObject> towers = new List<GameObject>();

    public GameObject SearchTowerObject(Vector3 position)
    {
        if (towers.Count <= 0)
        {
            return null;
        }

        //タワーが破壊されたらリストから除外
        for (int i = towers.Count - 1; i >= 0; i--)
        {
            if (towers[i] == null)
            {
                towers.RemoveAt(i);
            }
        }

        int count = 0;
        float dis = Vector3.Distance(position, towers[0].transform.position);
        for (int i = 1; i < towers.Count; i++)
        {
            float d = Vector3.Distance(position, towers[i].transform.position);
            if (dis > d)
            {
                count = i;
            }
        }

        return towers[count];
    }
}
