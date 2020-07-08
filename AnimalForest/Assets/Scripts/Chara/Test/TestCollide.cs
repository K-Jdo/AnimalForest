using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollide : MonoBehaviour
{
    [SerializeField] GameObject obj = default;
    Character character;
    private void Start()
    {
        character = obj.GetComponent<Character>();
    }

    private void Update()
    {
        if(character.animation_type != Character.AnimaionType.attack)
        {
            transform.position = obj.transform.transform.position;
            transform.rotation = obj.transform.rotation;
        }
    }
}
