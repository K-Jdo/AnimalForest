﻿//F.D.
//試験用後で消す
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
