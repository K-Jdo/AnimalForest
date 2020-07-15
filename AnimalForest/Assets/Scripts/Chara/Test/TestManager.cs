// K.Joudo. 2020
using UnityEngine;

// マネージャーをテストするクラス
// 使わなくなったら消すこと
public class TestManager : SingletonMonoBehaviour<TestManager>
{
    public GameObject tower;

    protected override void Awake()
    {
        base.Awake();
    }
}
