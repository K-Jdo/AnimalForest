// K.Joudo. 2020

using UnityEngine;

// シマウマの処理をするクラス
// 範囲攻撃の実装対象
public class Giraffe : Animal
{
    protected override void Awake()
    {
        status = new Status(150, 25, 10, 1.5f, 1000, "キリン");
        base.Awake();
    }

    /// <summary>
    /// 範囲攻撃に上書き
    /// </summary>
    protected override void Attack()
    {
        // キリンは当たり変更を別にするためここでは上書きして何もしなくする
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(status.hp);
    }
}
